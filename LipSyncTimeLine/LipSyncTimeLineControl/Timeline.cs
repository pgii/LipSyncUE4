using LipSyncTimeLineControl.Enums;
using LipSyncTimeLineControl.Events;
using LipSyncTimeLineControl.Helper;
using LipSyncTimeLineControl.Models;
using LipSyncTimeLineControl.Popup;
using LipSyncTimeLineControl.ToolTipCustom;
using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LipSyncTimeLineControl
{
    public partial class Timeline : Control
    {
        private const float DraggingThreshold = 3f;

        public EventHandler<SelectionChangedEventArgs> SelectionChanged;

        public EventHandler<SoundPlayerTickEventsArgs> SoundPlayerTick;

        private void InvokeSelectionChanged(SelectionChangedEventArgs eventArgs = null)
        {
            SelectionChanged?.Invoke(this, eventArgs ?? SelectionChangedEventArgs.Empty);
        }
        private void InvokeSoundPlayerTick(SoundPlayerTickEventsArgs eventArgs = null)
        {
            SoundPlayerTick?.Invoke(this, eventArgs ?? SoundPlayerTickEventsArgs.Empty);
        }

        [Description("How high a single track should be.")]
        [Category("Layout")]
        public int TrackHeight { get; set; } = 50;

        [Description("How wide/high the border on a track item should be.")]
        [Category("Layout")]
        public int TrackBorderSize { get; set; } = 2;

        [Description("How much space should be left between every track.")]
        [Category("Layout")]
        public int TrackSpacing { get; set; } = 1;

        [Description("The width of the label section before the tracks.")]
        [Category("Layout")]
        private int TrackLabelWidth { get; } = 100;

        private readonly SizeF _playHeadExtents = new SizeF(5, 16);

        [Description("The background color of the timeline.")]
        [Category("Drawing")]
        public Color BackgroundColor { get; set; } = Color.Black;

        internal PointF RenderingOffset => _renderingOffset;

        private PointF _renderingOffset = PointF.Empty;

        internal PointF RenderingScale => _renderingScale;

        private PointF _renderingScale = new PointF(1, 1);

        [Description("The transparency of the background grid.")]
        [Category("Drawing")]
        public int GridAlpha { get; set; } = 40;

        private AudioFileReader _soundPlayer;

        private IWavePlayer _wavePlayer;

        private readonly Timer _soundPlayerTimer = new Timer();

        private PopupContextTrackValue _popupContextTrack;

        private PopupContextTrackText _popupContextTrackText;

        private PopupContextContainer _popupContextContainer;

        private readonly LipSyncTimeLineClock _lipSyncTimeLineClock = new LipSyncTimeLineClock();

        private readonly List<TimelinePartBase> _parts = new List<TimelinePartBase>();

        private readonly List<TimelineTrackBase> _selectedTracks = new List<TimelineTrackBase>();

        private BehaviorModeEnum CurrentMode { get; set; }

        private List<TimelineTrackBase> _trackSurrogates = new List<TimelineTrackBase>();

        private PointF _dragOrigin;

        private PointF _selectionOrigin;

        private PointF _panOrigin;

        private PointF _renderingOffsetBeforePan = PointF.Empty;

        private RectangleF _selectionRectangle = RectangleF.Empty;

        private RectangleEdgeEnum _activeEdge = RectangleEdgeEnum.None;

        readonly ToolTipTrack _toolTipTrack = new ToolTipTrack();

        public Timeline()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserPaint, true);

            AddPart(new AudioTrackTimelineParts("AudioTrack"));
            AddPart(new MorphTimelineParts("Phoneme", TimelineTrackTypeEnum.Phoneme));
            AddPart(new MorphTimelineParts("Expression01", TimelineTrackTypeEnum.Expression));
            AddPart(new MorphTimelineParts("Expression02", TimelineTrackTypeEnum.Expression));
            AddPart(new MorphTimelineParts("Expression03", TimelineTrackTypeEnum.Expression));
            AddPart(new TextTimelineParts("Text"));
            
            _soundPlayerTimer.Interval = 50;
            _soundPlayerTimer.Tick += SoundPlayerTimerTick;
        }

        private static void WavePlayerOnPlaybackStopped(object sender, StoppedEventArgs stoppedEventArgs)
        {
            if (stoppedEventArgs.Exception != null)
                MessageBox.Show(stoppedEventArgs.Exception.Message, @"Playback Stopped Unexpectedly");
        }

        private void AddPart(TimelinePartBase part)
        {
            _parts.Add(part);

            RecalculateScrollbarBounds();
            Invalidate();
        }

        public void AddTextTrack()
        {
            TimelinePartBase textPart = _parts.FirstOrDefault(x => x.TimelineTrackType == TimelineTrackTypeEnum.Text);

            if (textPart != null)
            {
                float maxPosition = 0;
                if (textPart.TrackElements.Count > 0)
                    maxPosition = textPart.TrackElements.Max(x => x.End);
                textPart.TrackElements.Add(new TextTimelineTrack("", maxPosition, maxPosition + 50, 0));

                RecalculateScrollbarBounds();
                Invalidate();
            }
        }

        private void SoundPlayerTimerTick(object myObject, EventArgs e)
        {
            if (_soundPlayer != null)
            {
                _lipSyncTimeLineClock.Value = _soundPlayer.CurrentTime.TotalMilliseconds;
                Tick();
            }
        }

        private void Tick()
        {
            if (_lipSyncTimeLineClock.IsRunning)
            {
                InvokeSoundPlayerTick(new SoundPlayerTickEventsArgs(_lipSyncTimeLineClock.Value));
                Invalidate();
            }
        }

        public void LoadWaveFile(string filepath)
        {
            AudioTrackTimelineTrack audioTrackTimelineTrack = GetAudioTrackTimelineTrack();

            if (audioTrackTimelineTrack != null)
            {
                if (File.Exists(filepath))
                {
                    _soundPlayer = new AudioFileReader(filepath);
                    _wavePlayer = new WaveOut();
                    _wavePlayer.PlaybackStopped += WavePlayerOnPlaybackStopped;
                    _wavePlayer.Init(_soundPlayer);
                    audioTrackTimelineTrack.End = (float) _soundPlayer.TotalTime.TotalSeconds * 100f;

                    RecalculateScrollbarBounds();
                    Invalidate();
                }
                else
                {
                    throw new FileLoadException("File not found");
                }
            }
        }

        // {"AudioTrack":{"Name":"","Start":0.0,"End":0.0,"Value":1.0},
        // "Phoneme":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}],
        // "Expression01":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}],
        // "Expression02":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}],
        // "Expression03":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}]}
        // "Text":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}]}
        public void SaveProject()
        {
            Dictionary<string, JToken> partsDictionary = new Dictionary<string, JToken>();

            foreach (TimelinePartBase part in _parts)
            {
                switch (part.TimelineTrackType)
                {
                    case TimelineTrackTypeEnum.AudioTrack:
                    {
                        JObject trackObject = new JObject
                        {
                            {"Name", part.TrackElements[0].Name},
                            {"Start", part.TrackElements[0].Start / 100},
                            {"End", part.TrackElements[0].End / 100},
                            {"Value", part.TrackElements[0].Value}
                        };
                        partsDictionary.Add("AudioTrack", trackObject);
                        break;
                    }
                    case TimelineTrackTypeEnum.Phoneme:
                    {
                        JArray phonemeTrackList = new JArray();

                        List<TimelineTrackBase> trackSortedList = part.TrackElements.OrderBy(x => x.Start).ToList();

                        foreach (TimelineTrackBase trackElement in trackSortedList)
                        {
                            JObject trackObject = new JObject
                            {
                                {"Name", trackElement.Name},
                                {"Start", trackElement.Start / 100},
                                {"End", trackElement.End / 100},
                                {"Value", trackElement.Value}
                            };
                            phonemeTrackList.Add(trackObject);
                        }

                        partsDictionary.Add("Phoneme", phonemeTrackList);
                        break;
                    }
                    case TimelineTrackTypeEnum.Expression:
                    {
                        JArray expTrackList = new JArray();

                        List<TimelineTrackBase> trackSortedList = part.TrackElements.OrderBy(x => x.Start).ToList();

                        foreach (TimelineTrackBase trackElement in trackSortedList)
                        {
                            JObject trackObject = new JObject
                            {
                                {"Name", trackElement.Name},
                                {"Start", trackElement.Start / 100},
                                {"End", trackElement.End / 100},
                                {"Value", trackElement.Value}
                            };
                            expTrackList.Add(trackObject);
                        }

                        partsDictionary.Add(part.Name, expTrackList);
                        break;
                    }
                    case TimelineTrackTypeEnum.Text:
                    {
                        JArray textTrackList = new JArray();

                        List<TimelineTrackBase> trackSortedList = part.TrackElements.OrderBy(x => x.Start).ToList();

                        foreach (TimelineTrackBase trackElement in trackSortedList)
                        {
                            JObject trackObject = new JObject
                            {
                                {"Name", trackElement.Name},
                                {"Start", trackElement.Start / 100},
                                {"End", trackElement.End / 100},
                                {"Value", trackElement.Value}
                            };
                            textTrackList.Add(trackObject);
                        }

                        partsDictionary.Add(part.Name, textTrackList);
                        break;
                    }
                }
            }

            string jsonString = JsonConvert.SerializeObject(partsDictionary);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = @"LipSync Project|*.lsproject", 
                Title = @"Save LipSync Project File"
            };
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    sw.Write(jsonString);
                }
            }
        }

        // {"AudioTrack":{"Name":"","Start":0.0,"End":0.0,"Value":1.0},
        // "Phoneme":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}],
        // "Expression01":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}],
        // "Expression02":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}],
        // "Expression03":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}]}
        // "Text":[{"Name":"","Start":0.0,"End":0.0,"Value":1.0}]}
        public void Export()
        {
            List<JObject> partObjectList = new List<JObject>();
            JArray expressionTrackList = new JArray();
            foreach (TimelinePartBase part in _parts)
            {
                switch (part.TimelineTrackType)
                {
                    case TimelineTrackTypeEnum.AudioTrack:
                    {
                        JObject trackObject = new JObject
                        {
                            {"Name", part.TrackElements[0].Name},
                            {"Start", part.TrackElements[0].Start / 100},
                            {"End", part.TrackElements[0].End / 100},
                            {"Value", part.TrackElements[0].Value}
                        };

                        JObject partObject = new JObject
                        {
                            {"Name", "AudioTrack"}, 
                            {"Value", JsonConvert.SerializeObject(new Dictionary<string, JObject> {{"AudioTrack", trackObject}})}
                        };
                        partObjectList.Add(partObject);

                        break;
                    }
                    case TimelineTrackTypeEnum.Phoneme:
                    {
                        JArray phonemeTrackList = new JArray();

                        List<TimelineTrackBase> trackSortedList = part.TrackElements.OrderBy(x => x.Start).ToList();

                        foreach (TimelineTrackBase trackElement in trackSortedList)
                        {
                            JObject trackObject = new JObject
                            {
                                {"Name", trackElement.Name},
                                {"Start", trackElement.Start / 100},
                                {"End", trackElement.End / 100},
                                {"Value", trackElement.Value}
                            };
                            phonemeTrackList.Add(trackObject);
                        }

                        JObject partObject = new JObject
                        {
                            {"Name", "Phoneme"},
                            {"Value", JsonConvert.SerializeObject(new Dictionary<string, JArray>{{"Phoneme", phonemeTrackList}})}
                        };
                        partObjectList.Add(partObject);

                        break;
                    }
                    case TimelineTrackTypeEnum.Expression:
                    {
                        List<TimelineTrackBase> trackSortedList = part.TrackElements.OrderBy(x => x.Start).ToList();

                        foreach (TimelineTrackBase trackElement in trackSortedList)
                        {
                            JObject trackObject = new JObject
                            {
                                {"Name", trackElement.Name},
                                {"Start", trackElement.Start / 100},
                                {"End", trackElement.End / 100},
                                {"Value", trackElement.Value}
                            };
                            expressionTrackList.Add(trackObject);
                        }
                        break;
                    }
                    case TimelineTrackTypeEnum.Text:
                    {
                        JArray textTrackList = new JArray();

                        List<TimelineTrackBase> trackSortedList = part.TrackElements.OrderBy(x => x.Start).ToList();

                        foreach (TimelineTrackBase trackElement in trackSortedList)
                        {
                            JObject trackObject = new JObject
                            {
                                {"Name", trackElement.Name},
                                {"Start", trackElement.Start / 100},
                                {"End", trackElement.End / 100},
                                {"Value", trackElement.Value}
                            };
                            textTrackList.Add(trackObject);
                        }

                        JObject partObject = new JObject
                        {
                            {"Name", "Text"},
                            {"Value", JsonConvert.SerializeObject(new Dictionary<string, JArray>{{"Text", textTrackList}})}
                        };
                        partObjectList.Add(partObject);
                        break;
                    }
                }
            }

            JObject partObjectExpression = new JObject
            {
                {"Name", "Expression"},
                {"Value", JsonConvert.SerializeObject(new Dictionary<string, JArray>{{ "Expression", expressionTrackList}})}
            };
            partObjectList.Add(partObjectExpression);

            string jsonString = JsonConvert.SerializeObject(partObjectList);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = @"Morph PlayList JSON|*.json", 
                Title = @"Save Morph PlayList JSON File"
            };
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    sw.Write(jsonString);
                }
            }
        }

        public void LoadProject()
        {
            string jsonString = null;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = @"LipSync Project|*.lsproject", 
                Title = @"Open LipSync Project File"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    jsonString = sr.ReadToEnd();
                }
            }

            if (jsonString == null)
                return;

            Dictionary<string, object> partsDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            foreach (string stringKey in partsDictionary.Keys)
            {
                foreach (TimelinePartBase part in _parts.Where(x => x.Name == stringKey))
                {
                    switch (stringKey)
                    {
                        case "AudioTrack":
                        {
                            JObject partObject = (JObject) partsDictionary[stringKey];

                            string name = (string) partObject.GetValue("Name");
                            float start = (float) partObject.GetValue("Start") * 100;
                            float end = (float) partObject.GetValue("End") * 100;
                            float value = (float) partObject.GetValue("Value");

                            part.TrackElements[0].Name = name;
                            part.TrackElements[0].Start = start;
                            part.TrackElements[0].End = end;
                            part.TrackElements[0].Value = value;
                            break;
                        }
                        case "Phoneme":
                        {
                            part.TrackElements.Clear();

                            JArray partObjectArray = (JArray) partsDictionary[stringKey];

                            foreach (JToken jToken in partObjectArray)
                            {
                                JObject partObject = (JObject) jToken;
                                string name = (string) partObject.GetValue("Name");
                                float start = (float) partObject.GetValue("Start") * 100;
                                float end = (float) partObject.GetValue("End") * 100;
                                float value = (float) partObject.GetValue("Value");
                                Bitmap bitmap = MorphTemplate.MorphTemplateList.FirstOrDefault(x => x.Name == name)?.Bitmap;

                                if (MorphTemplate.MorphTemplateList.Any(x => x.Name == name))
                                {
                                    MorphTimelineTrack morphTimelineTrack = new MorphTimelineTrack(name, start, end, value, TimelineTrackTypeEnum.Phoneme, bitmap);
                                    part.TrackElements.Add(morphTimelineTrack);
                                }
                            }
                            break;
                        }
                        default:
                        {
                            if (stringKey.Contains("Expression"))
                            {
                                part.TrackElements.Clear();

                                JArray partObjectArray = (JArray) partsDictionary[stringKey];

                                foreach (JToken jToken in partObjectArray)
                                {
                                    JObject partObject = (JObject) jToken;
                                    string name = (string) partObject.GetValue("Name");
                                    float start = (float) partObject.GetValue("Start") * 100;
                                    float end = (float) partObject.GetValue("End") * 100;
                                    float value = (float) partObject.GetValue("Value");

                                    if (MorphTemplate.MorphTemplateList.Any(x => x.Name == name))
                                    {
                                        MorphTimelineTrack morphTimelineTrack = new MorphTimelineTrack(name, start, end, value, TimelineTrackTypeEnum.Expression);
                                        part.TrackElements.Add(morphTimelineTrack);
                                    }
                                }
                            }
                            break;
                        }
                        case "Text":
                        {
                            part.TrackElements.Clear();

                            JArray partObjectArray = (JArray)partsDictionary[stringKey];

                            foreach (JToken jToken in partObjectArray)
                            {
                                JObject partObject = (JObject)jToken;
                                string name = (string)partObject.GetValue("Name");
                                float start = (float)partObject.GetValue("Start") * 100;
                                float end = (float)partObject.GetValue("End") * 100;
                                float value = (float)partObject.GetValue("Value");
                                Bitmap bitmap = MorphTemplate.MorphTemplateList.FirstOrDefault(x => x.Name == name)?.Bitmap;

                                MorphTimelineTrack morphTimelineTrack = new MorphTimelineTrack(name, start, end, value, TimelineTrackTypeEnum.Text, bitmap);

                                part.TrackElements.Add(morphTimelineTrack);
                            }

                            break;
                        }
                    }
                }
            }


            Invalidate();
        }

        public TimelineTrackBase GetCurrentPhonemeFromElapsedTime(double elapsedTime)
        {
            foreach (TimelinePartBase part in _parts.Where(x => x.Name == "Phoneme"))
            {
                foreach (TimelineTrackBase trackElement in part.TrackElements)
                {
                    if (elapsedTime >= trackElement.Start && elapsedTime <= trackElement.End)
                    {
                        return trackElement;
                    }
                }
            }

            return null;
        }

        private AudioTrackTimelineTrack GetAudioTrackTimelineTrack()
        {
            AudioTrackTimelineParts audioTrackTimelineParts = _parts.OfType<AudioTrackTimelineParts>().FirstOrDefault();

            if (audioTrackTimelineParts?.TrackElements[0] is AudioTrackTimelineTrack audioTrackTimelineTrack)
                return audioTrackTimelineTrack;

            return null;
        }

        private void RecalculateScrollbarBounds()
        {
            ScrollbarV.Max = (int) (_parts.Count * (TrackHeight + TrackSpacing) * _renderingScale.Y);
            ScrollbarH.Max = (int) (_parts.Max(t => t.TrackElements.Any() ? t.TrackElements.Max(te => te.End) : 0) * _renderingScale.X);
            ScrollbarV.Refresh();
            ScrollbarH.Refresh();
        }

        internal Rectangle GetTrackAreaBounds()
        {
            Rectangle trackArea = new Rectangle
            {
                X = TrackLabelWidth,
                Y = (int) _playHeadExtents.Height,
                Width = Width - ScrollbarV.Width,
                Height = Height - ScrollbarH.Height
            };

            return trackArea;
        }

        private TimelineTrackBase TrackHitTest(PointF test)
        {
            List<TimelineTrackBase> timelineTrackList = _parts.SelectMany(t => t.TrackElements).ToList();

            foreach (TimelineTrackBase track in timelineTrackList)
            {
                int trackIndex = TrackIndexForTrack(track);

                RectangleF trackExtent = BoundsHelper.GetTrackExtents(track, this, trackIndex);

                if (trackExtent.Contains(test))
                    return track;
            }

            return null;
        }

        private int TrackLabelHitTest(PointF test)
        {
            if (test.X > 0 && test.X < TrackLabelWidth)
                return PartIndexAtPoint(test);
            return -1;
        }

        private TimelinePartBase PartTimelineHitTest(PointF test)
        {
            PointF location = new PointF(test.X, test.Y);

            int trackTimelineIndex = PartIndexAtPoint(location);

            if (trackTimelineIndex > -1)
            {
                TimelinePartBase part = _parts[trackTimelineIndex];
                return part;
            }

            return null;
        }

        private int PartIndexAtPoint(PointF test)
        {
            for (int indexPart = 0; indexPart < _parts.Count; indexPart++)
            {
                TimelinePartBase track = _parts[indexPart];
                RectangleF partExtent = BoundsHelper.GetTrackExtents(track.TrackElements.FirstOrDefault(), this, indexPart);

                if (partExtent.Top < test.Y && partExtent.Bottom > test.Y)
                    return indexPart;
            }
            return -1;
        }

        private static bool IsKeyDown(Keys key, Keys keys = Keys.None)
        {
            if (Keys.None == keys)
                keys = ModifierKeys;
            return (keys & key) != 0;
        }

        private void SetClockFromMousePosition(PointF location)
        {
            Rectangle trackAreaBounds = GetTrackAreaBounds();

            float clockValue = (location.X - _renderingOffset.X - trackAreaBounds.X) * (1 / _renderingScale.X) * 10f;
            _lipSyncTimeLineClock.Value = clockValue;

            if (_soundPlayer?.TotalTime.TotalMilliseconds > 0 && clockValue > 0)
                _soundPlayer.CurrentTime = TimeSpan.FromMilliseconds(clockValue);
        }

        private void RemoveSelectionTrack()
        {
            List<TimelineTrackBase> removeTracks = new List<TimelineTrackBase>();

            foreach (TimelineTrackBase selectedTrack in _selectedTracks)
            {
                foreach (TimelinePartBase part in _parts)
                {
                    foreach (TimelineTrackBase trackElement in part.TrackElements)
                    {
                        if (!trackElement.IsLocked && trackElement == selectedTrack)
                        {
                            removeTracks.Add(selectedTrack);
                        }
                    }
                }
            }

            foreach (TimelinePartBase part in _parts)
            {
                foreach (TimelineTrackBase removeTrack in removeTracks)
                {
                    part.TrackElements.Remove(removeTrack);
                }
            }
        }

        private void Redraw(Graphics graphics)
        {
            graphics.Clear(BackgroundColor);

            DrawBackground(graphics);
            DrawTracks(graphics);
            DrawTracksSurrogate(_trackSurrogates, graphics);
            DrawSelectionRectangle(graphics);
            DrawTrackLabels(graphics);
            DrawPlayHead(graphics);

            ScrollbarH.Refresh();
            ScrollbarV.Refresh();
        }

        private void DrawBackground(Graphics graphics)
        {
            Rectangle trackAreaBounds = GetTrackAreaBounds();

            Pen gridPen = new Pen(Color.FromArgb(GridAlpha, GridAlpha, GridAlpha));
            int firstLineY = (int) (TrackHeight * _renderingScale.Y + trackAreaBounds.Y + _renderingOffset.Y);
            int actualRowHeight = (int) (TrackHeight * _renderingScale.Y + TrackSpacing);
            actualRowHeight = Math.Max(1, actualRowHeight);

            for (int y = firstLineY; y < Height; y += actualRowHeight)
                graphics.DrawLine(gridPen, trackAreaBounds.X, y, trackAreaBounds.Width, y);

            float minorTickDistance = _renderingScale.X;
            int minorTickOffset = (int) (_renderingOffset.X % minorTickDistance);

            int tickDistance = (int) (10f * _renderingScale.X);
            tickDistance = Math.Max(1, tickDistance);

            int minuteDistance = tickDistance * 10;

            int tickOffset = (int) (_renderingOffset.X % tickDistance);
            int minuteOffset = (int) (_renderingOffset.X % minuteDistance);

            int columnWidth = (int) (10 * _renderingScale.X);
            columnWidth = Math.Max(1, columnWidth);

            if (minorTickDistance > 5.0f)
            {
                Pen pen = new Pen(Color.FromArgb(30, 30, 30)) {DashStyle = DashStyle.Dot};

                using (Pen minorGridPen = pen)
                {
                    for (float x = minorTickOffset; x < Width; x += minorTickDistance)
                        graphics.DrawLine(minorGridPen, trackAreaBounds.X + x, trackAreaBounds.Y, trackAreaBounds.X + x, trackAreaBounds.Height);
                }
            }

            int minutePenColor = (int) (255 * Math.Min(255, GridAlpha * 2) / 255f);
            Pen brightPen = new Pen(Color.FromArgb(minutePenColor, minutePenColor, minutePenColor));
            for (int x = tickOffset + tickDistance; x < Width; x += columnWidth)
            {
                Pen penToUse = (x - minuteOffset) % minuteDistance == 0 ? brightPen : gridPen;
                graphics.DrawLine(penToUse, trackAreaBounds.X + x, trackAreaBounds.Y, trackAreaBounds.X + x, trackAreaBounds.Height);
            }

            gridPen.Dispose();
            brightPen.Dispose();
        }

        private void DrawTracks(Graphics graphics)
        {
            Rectangle trackAreaBounds = GetTrackAreaBounds();

            List<Color> colors = ColorHelper.GetRandomColors(_parts.Count);

            for (int indexTrack = 0; indexTrack < _parts.Count; indexTrack++)
            {
                TimelinePartBase part = _parts[indexTrack];

                foreach (TimelineTrackBase track in part.TrackElements)
                {
                    RectangleF trackExtent = BoundsHelper.GetTrackExtents(track, this, indexTrack);

                    if (!trackAreaBounds.IntersectsWith(trackExtent.ToRectangle()))
                        continue;

                    int trackIndex = TrackIndexForTrack(track);

                    Color trackColor = ColorHelper.AdjustColor(colors[trackIndex], 0, -0.1, -0.2);
                    Color borderColor = Color.FromArgb(128, Color.Black);

                    if (_selectedTracks.Contains(track))
                        borderColor = Color.WhiteSmoke;

                    graphics.FillRectangle(track is SurrogateTrack ? new SolidBrush(Color.FromArgb(128, trackColor)) : new SolidBrush(trackColor), trackExtent);

                    trackExtent.X += TrackBorderSize / 2f;
                    trackExtent.Y += TrackBorderSize / 2f;
                    trackExtent.Height -= TrackBorderSize;
                    trackExtent.Width -= TrackBorderSize;

                    graphics.DrawRectangle(new Pen(borderColor, TrackBorderSize), trackExtent.X, trackExtent.Y,
                        trackExtent.Width, trackExtent.Height);

                    using (Font font = new Font("Arial", 6, FontStyle.Bold, GraphicsUnit.Point))
                    {
                        StringFormat stringFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };

                        graphics.DrawString(track.Name, font, Brushes.White, new RectangleF(trackExtent.X, trackExtent.Y, trackExtent.Width, trackExtent.Height), stringFormat);
                    }
                }
            }
        }

        private void DrawTracksSurrogate(IEnumerable<TimelineTrackBase> tracks, Graphics graphics)
        {
            Rectangle trackAreaBounds = GetTrackAreaBounds();

            List<Color> colors = ColorHelper.GetRandomColors(_parts.Count);

            foreach (TimelineTrackBase track in tracks)
            {
                int trackIndex = TrackIndexForTrack(track);

                RectangleF trackExtent = BoundsHelper.GetTrackExtents(track, this, trackIndex);

                if (!trackAreaBounds.IntersectsWith(trackExtent.ToRectangle()))
                    continue;

                Color trackColor = ColorHelper.AdjustColor(colors[trackIndex], 0, -0.1, -0.2);
                Color borderColor = Color.FromArgb(128, Color.Black);

                if (_selectedTracks.Contains(track))
                    borderColor = Color.WhiteSmoke;

                graphics.FillRectangle(track is SurrogateTrack ? new SolidBrush(Color.FromArgb(128, trackColor)) : new SolidBrush(trackColor), trackExtent);

                trackExtent.X += TrackBorderSize / 2f;
                trackExtent.Y += TrackBorderSize / 2f;
                trackExtent.Height -= TrackBorderSize;
                trackExtent.Width -= TrackBorderSize;

                graphics.DrawRectangle(new Pen(borderColor, TrackBorderSize), trackExtent.X, trackExtent.Y, trackExtent.Width, trackExtent.Height);
            }
        }

        private void DrawTrackLabels(Graphics graphics)
        {
            for (int indexTrack = 0; indexTrack < _parts.Count; indexTrack++)
            {
                TimelinePartBase part = _parts[indexTrack];

                RectangleF trackExtents = BoundsHelper.GetTrackExtents(part.TrackElements.FirstOrDefault(), this, indexTrack);

                RectangleF labelRect = new RectangleF(0, trackExtents.Y, TrackLabelWidth, trackExtents.Height);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), labelRect);

                using (Font font = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point))
                {
                    StringFormat stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    };

                    graphics.DrawString(part.Name, font, Brushes.White, labelRect, stringFormat);
                }
            }
        }

        private void DrawPlayHead(Graphics graphics)
        {
            if (null != _lipSyncTimeLineClock)
            {
                Rectangle trackAreaBounds = GetTrackAreaBounds();

                graphics.FillRectangle(Brushes.WhiteSmoke, 0, 0, Width, _playHeadExtents.Height);

                int tickDistance = (int)(10f * _renderingScale.X);
                tickDistance = Math.Max(1, tickDistance);

                int minuteDistance = tickDistance * 10;

                int tickOffset = (int)(_renderingOffset.X % tickDistance);
                int minuteOffset = (int)(_renderingOffset.X % minuteDistance);

                int columnWidth = (int)(10 * _renderingScale.X);
                columnWidth = Math.Max(1, columnWidth);

                for (int x = tickOffset + tickDistance; x < Width; x += columnWidth)
                {
                    if ((x - minuteOffset) % minuteDistance == 0)
                        graphics.DrawLine(Pens.Red, trackAreaBounds.X + x, _playHeadExtents.Height / 2, trackAreaBounds.X + x, _playHeadExtents.Height);
                }

                float playHeadOffset = (float) (trackAreaBounds.X + _lipSyncTimeLineClock.Value * 0.1f * _renderingScale.X) + _renderingOffset.X;

                if (playHeadOffset < trackAreaBounds.X || playHeadOffset > trackAreaBounds.X + trackAreaBounds.Width)
                    return;

                graphics.DrawLine(Pens.LightGreen, playHeadOffset, trackAreaBounds.Y, playHeadOffset, trackAreaBounds.Height);

                graphics.FillRectangle(Brushes.LightGreen, playHeadOffset - _playHeadExtents.Width / 2, 0, _playHeadExtents.Width, _playHeadExtents.Height);
            }
        }

        private void DrawSelectionRectangle(Graphics graphics)
        {
            graphics.DrawRectangle(
                new Pen(Color.LightGray, 1)
                {
                    DashStyle = DashStyle.Dot
                }, _selectionRectangle.ToRectangle());
        }

        private int TrackIndexForTrack(TimelineTrackBase track)
        {
            TimelineTrackBase trackToLookFor = track;

            if (track is SurrogateTrack surrogate)
                trackToLookFor = surrogate.SubstituteFor;

            return _parts.FindIndex(t => t.TrackElements.Contains(trackToLookFor));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Redraw(e.Graphics);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.A && IsKeyDown(Keys.Control))
            {
                InvokeSelectionChanged(new SelectionChangedEventArgs(null, _selectedTracks));
                _selectedTracks.Clear();

                foreach (TimelineTrackBase track in _parts.SelectMany(t => t.TrackElements))
                    _selectedTracks.Add(track);

                InvokeSelectionChanged(new SelectionChangedEventArgs(_selectedTracks, null));
                Invalidate();

            }
            else if (e.KeyCode == Keys.D && IsKeyDown(Keys.Control))
            {
                InvokeSelectionChanged(new SelectionChangedEventArgs(null, _selectedTracks));
                _selectedTracks.Clear();
                Invalidate();
            }
            else if (e.KeyCode == Keys.Delete & _selectedTracks.Count > 0)
            {
                RemoveSelectionTrack();
                _selectedTracks.Clear();
                Invalidate();
            }

            if (e.KeyCode == Keys.Space)
            {
                if (_lipSyncTimeLineClock.IsRunning)
                {
                    _lipSyncTimeLineClock.Pause();
                    _wavePlayer?.Stop();
                    _soundPlayerTimer.Enabled = false;
                    Debug.WriteLine("Paused.");
                }
                else
                {
                    _lipSyncTimeLineClock.Play();
                    _wavePlayer?.Play();
                    _soundPlayerTimer.Enabled = true;
                    Debug.WriteLine("Running.");
                }
            }

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            PointF location = new PointF(e.X, e.Y);

            TimelineTrackBase focusedTrack = TrackHitTest(location);

            if ((e.Button & MouseButtons.Left) != 0)
            {
                switch (CurrentMode)
                {
                    case BehaviorModeEnum.MovingSelection:
                    {
                        Cursor = Cursors.SizeWE;

                        PointF delta = PointF.Subtract(location, new SizeF(_dragOrigin));
                        delta = AcceptableMovementDelta(delta);

                        foreach (TimelineTrackBase timelineTrack in _trackSurrogates)
                        {
                            if (timelineTrack.IsLocked)
                                continue;

                            SurrogateTrack selectedTrack = (SurrogateTrack) timelineTrack;

                            float length = selectedTrack.SubstituteFor.End - selectedTrack.SubstituteFor.Start;

                            float proposedStart = Math.Max(0,
                                selectedTrack.SubstituteFor.Start + delta.X * (1 / _renderingScale.X));

                            if (!IsKeyDown(Keys.Alt))
                                proposedStart = (float) Math.Round(proposedStart);

                            selectedTrack.Start = proposedStart;
                            selectedTrack.End = proposedStart + length;
                        }

                        Invalidate();
                        break;
                    }
                    case BehaviorModeEnum.ResizingSelection:
                    {
                        Cursor = Cursors.SizeWE;

                        PointF delta = PointF.Subtract(location, new SizeF(_dragOrigin));

                        foreach (TimelineTrackBase timelineTrack in _trackSurrogates)
                        {
                            if (timelineTrack.IsLocked)
                                continue;

                            SurrogateTrack selectedTrack = (SurrogateTrack) timelineTrack;

                            float proposedStart = selectedTrack.SubstituteFor.Start;
                            float proposedEnd = selectedTrack.SubstituteFor.End;

                            if ((_activeEdge & RectangleEdgeEnum.Left) != 0)
                            {
                                delta = AcceptableResizingDelta(delta, true);
                                proposedStart = Math.Max(0, proposedStart + delta.X * (1 / _renderingScale.X));

                                if (!IsKeyDown(Keys.Alt))
                                    proposedStart = (float) Math.Round(proposedStart);
                            }
                            else if ((_activeEdge & RectangleEdgeEnum.Right) != 0)
                            {
                                delta = AcceptableResizingDelta(delta, false);
                                proposedEnd = Math.Max(0, proposedEnd + delta.X * (1 / _renderingScale.X));

                                if (!IsKeyDown(Keys.Alt))
                                    proposedEnd = (float) Math.Round(proposedEnd);
                            }

                            selectedTrack.Start = proposedStart;
                            selectedTrack.End = proposedEnd;
                        }

                        Invalidate();
                        break;
                    }
                    case BehaviorModeEnum.Selecting:
                        Cursor = Cursors.Cross;
                        _selectionRectangle = RectangleHelper.Normalize(_selectionOrigin, location).ToRectangle();
                        Invalidate();
                        break;
                    case BehaviorModeEnum.RequestMovingSelection:
                    case BehaviorModeEnum.RequestResizingSelection:
                    {
                        PointF delta = PointF.Subtract(location, new SizeF(_dragOrigin));
                        if (Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y) > DraggingThreshold)
                        {
                            switch (CurrentMode)
                            {
                                case BehaviorModeEnum.RequestMovingSelection:
                                    CurrentMode = BehaviorModeEnum.MovingSelection;
                                    break;
                                case BehaviorModeEnum.RequestResizingSelection:
                                    CurrentMode = BehaviorModeEnum.ResizingSelection;
                                    break;
                            }
                            _trackSurrogates = SurrogateHelper.GetSurrogates(_selectedTracks);
                        }

                        break;
                    }
                    case BehaviorModeEnum.TimeScrub:
                        SetClockFromMousePosition(location);
                        Invalidate();
                        break;
                }
            }
            else if ((e.Button & MouseButtons.Middle) != 0)
            {
                PointF delta = PointF.Subtract(location, new SizeF(_panOrigin));
                _renderingOffset = PointF.Add(_renderingOffsetBeforePan, new SizeF(delta));
                _renderingOffset.X = Math.Max(-ScrollbarH.Max, Math.Min(0, _renderingOffset.X));
                _renderingOffset.Y = Math.Max(-ScrollbarV.Max, Math.Min(0, _renderingOffset.Y));
                ScrollbarH.Value = (int) -_renderingOffset.X;
                ScrollbarV.Value = (int) -_renderingOffset.Y;

            }
            else
            {
                if (null != focusedTrack)
                {
                    int trackIndex = TrackIndexForTrack(focusedTrack);
                    RectangleF trackExtents = BoundsHelper.GetTrackExtents(focusedTrack, this, trackIndex);
                    RectangleEdgeEnum isPointOnEdge = RectangleHelper.IsPointOnEdge(trackExtents, location, 3f);

                    switch (isPointOnEdge)
                    {
                        case RectangleEdgeEnum.Top:
                        case RectangleEdgeEnum.Bottom:
                            Cursor = Cursors.SizeNS;
                            break;
                        case RectangleEdgeEnum.Right:
                        case RectangleEdgeEnum.Left:
                            Cursor = Cursors.SizeWE;
                            break;
                        case RectangleEdgeEnum.Top | RectangleEdgeEnum.Left:
                        case RectangleEdgeEnum.Bottom | RectangleEdgeEnum.Right:
                            Cursor = Cursors.SizeNWSE;
                            break;
                        case RectangleEdgeEnum.Top | RectangleEdgeEnum.Right:
                        case RectangleEdgeEnum.Bottom | RectangleEdgeEnum.Left:
                            Cursor = Cursors.SizeNESW;
                            break;
                        case RectangleEdgeEnum.None:
                            Cursor = Cursors.Arrow;
                            break;
                        default:
                            Cursor = Cursors.Arrow;
                            break;
                    }

                    if (trackExtents.Contains(e.Location))
                    {
                        _toolTipTrack.Show(focusedTrack, $"{focusedTrack.Name} Value: {focusedTrack.Value:N1}" , this, e.Location, 1000);
                    }
                }
                else
                {
                    Cursor = Cursors.Arrow;
                    _toolTipTrack.Hidden(this);
                }
            }
        }

        private PointF AcceptableMovementDelta(PointF delta)
        {
            PointF lastDelta;
            do
            {
                lastDelta = delta;

                foreach (TimelineTrackBase timelineTrack in _trackSurrogates)
                {
                    SurrogateTrack selectedTrack = (SurrogateTrack) timelineTrack;

                    float length = selectedTrack.SubstituteFor.End - selectedTrack.SubstituteFor.Start;

                    float proposedStart = Math.Max(0,
                        selectedTrack.SubstituteFor.Start + delta.X * (1 / _renderingScale.X));

                    if (proposedStart <= 0)
                    {
                        delta.X = -selectedTrack.SubstituteFor.Start * _renderingScale.X;
                        proposedStart = Math.Max(0, selectedTrack.SubstituteFor.Start + delta.X * (1 / _renderingScale.X));
                    }

                    int trackIndex = TrackIndexForTrack(selectedTrack);

                    RectangleF proposed = BoundsHelper.RectangleToTrackExtents(new RectangleF {X = proposedStart, Width = length}, this, trackIndex);

                    SurrogateTrack track = selectedTrack;
                    List<TimelineTrackBase> sortedTracks =
                        _parts[trackIndex].TrackElements
                            .Where(t => t != track.SubstituteFor && !_selectedTracks.Contains(t))
                            .OrderBy(t => t.Start).ToList();

                    if (BoundsHelper.IntersectsAny(proposed, sortedTracks.Select(t => BoundsHelper.GetTrackExtents(t, this, TrackIndexForTrack(t))).ToList()))
                    {
                        List<TimelineTrackBase> sortedTracksList = sortedTracks.ToList();

                        if (delta.X < 0)
                        {
                            for (int elementIndex = 0; elementIndex < sortedTracksList.Count; elementIndex++)
                            {
                                if (sortedTracksList[elementIndex].End < proposedStart)
                                    continue;

                                proposedStart = sortedTracksList[elementIndex].End;

                                if (elementIndex == sortedTracksList.Count - 1)
                                    break;

                                if (sortedTracksList[elementIndex + 1].Start < proposedStart + length)
                                    continue;

                                break;
                            }

                        }
                        else if (delta.X > 0)
                        {
                            for (int elementIndex = sortedTracksList.Count - 1; elementIndex >= 0; elementIndex--)
                            {
                                if (sortedTracksList[elementIndex].Start > proposedStart + length)
                                    continue;

                                proposedStart = sortedTracksList[elementIndex].Start - length;

                                if (elementIndex == 0)
                                    break;

                                if (sortedTracksList[elementIndex - 1].End > proposedStart)
                                    continue;

                                break;
                            }
                        }

                        delta.X = delta.X < 0 ? Math.Max(delta.X, (proposedStart - selectedTrack.SubstituteFor.Start) * _renderingScale.X) : Math.Min(delta.X, (proposedStart - selectedTrack.SubstituteFor.Start) * _renderingScale.X);
                    }

                    if (Math.Abs(delta.X) < 0.001f)
                    {
                        delta.X = 0;
                        return delta;
                    }
                }
            } while (!lastDelta.Equals(delta));

            return delta;
        }

        private PointF AcceptableResizingDelta(PointF delta, bool adjustStart)
        {
            foreach (TimelineTrackBase timelineTrack in _trackSurrogates)
            {
                SurrogateTrack selectedTrack = (SurrogateTrack) timelineTrack;

                float proposedStart = !adjustStart ? selectedTrack.SubstituteFor.Start : Math.Max(0, selectedTrack.SubstituteFor.Start + delta.X * (1 / _renderingScale.X));
                float proposedEnd = adjustStart ? selectedTrack.SubstituteFor.End : Math.Max(0, selectedTrack.SubstituteFor.End + delta.X * (1 / _renderingScale.X));

                int trackIndex = TrackIndexForTrack(selectedTrack);

                RectangleF proposed = BoundsHelper.RectangleToTrackExtents(
                    new RectangleF
                    {
                        X = proposedStart,
                        Width = proposedEnd - proposedStart
                    }, this, trackIndex);

                if (adjustStart && proposedStart <= 0)
                {
                    delta.X = -selectedTrack.SubstituteFor.Start * _renderingScale.X;
                    return delta;
                }

                SurrogateTrack track = selectedTrack;
                List<TimelineTrackBase> sortedTracks =
                    _parts[trackIndex].TrackElements
                        .Concat(_trackSurrogates.Where(t => t != track && TrackIndexForTrack(t) == trackIndex))
                        .Where(t => t != track.SubstituteFor && !_selectedTracks.Contains(t))
                        .OrderBy(t => t.Start).ToList();

                if (BoundsHelper.IntersectsAny(proposed, sortedTracks.Select(t => BoundsHelper.GetTrackExtents(t, this, TrackIndexForTrack(t))).ToList()))
                {
                    List<TimelineTrackBase> sortedTracksList = sortedTracks.ToList();

                    if (adjustStart)
                    {
                        for (int elementIndex = sortedTracksList.Count - 1; elementIndex >= 0; elementIndex--)
                        {
                            if (sortedTracksList[elementIndex].Start >= selectedTrack.SubstituteFor.Start)
                                continue;

                            proposedStart = sortedTracksList[elementIndex].End;
                            break;
                        }

                        delta.X = delta.X < 0 ? Math.Max(delta.X, (proposedStart - selectedTrack.SubstituteFor.Start) * _renderingScale.X) : Math.Min(delta.X, (proposedStart - selectedTrack.SubstituteFor.Start) * _renderingScale.X);
                    }
                    else
                    {
                        foreach (TimelineTrackBase sortedTrack in sortedTracksList)
                        {
                            if (!(sortedTrack.End <= selectedTrack.SubstituteFor.Start))
                            {
                                proposedEnd = sortedTrack.Start;
                                break;
                            }
                        }

                        delta.X = delta.X < 0 ? Math.Max(delta.X, (proposedEnd - selectedTrack.SubstituteFor.End) * _renderingScale.X) : Math.Min(delta.X, (proposedEnd - selectedTrack.SubstituteFor.End) * _renderingScale.X);
                    }
                }

                if (Math.Abs(0 - delta.X) < 0.001f)
                    return delta;
            }

            return delta;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            PointF location = new PointF(e.X, e.Y);

            if ((e.Button & MouseButtons.Left) != 0)
            {
                TimelineTrackBase focusedTrack = TrackHitTest(location);

                if (focusedTrack != null)
                {
                    if (!_selectedTracks.Contains(focusedTrack))
                    {
                        InvokeSelectionChanged(new SelectionChangedEventArgs(focusedTrack.Yield(), null));
                        if (!IsKeyDown(Keys.Control))
                        {
                            InvokeSelectionChanged(new SelectionChangedEventArgs(null, _selectedTracks));
                            _selectedTracks.Clear();
                        }

                        _selectedTracks.Add(focusedTrack);
                    }
                    else if (IsKeyDown(Keys.Control))
                    {
                        _selectedTracks.Remove(focusedTrack);
                        InvokeSelectionChanged(new SelectionChangedEventArgs(null, focusedTrack.Yield()));
                    }

                    _dragOrigin = location;

                    int trackIndex = TrackIndexForTrack(focusedTrack);

                    RectangleF trackExtents = BoundsHelper.GetTrackExtents(focusedTrack, this, trackIndex);
                    RectangleEdgeEnum isPointOnEdge = RectangleHelper.IsPointOnEdge(trackExtents, location, 3f);
                    
                    if (isPointOnEdge != RectangleEdgeEnum.None)
                    {
                        CurrentMode = BehaviorModeEnum.RequestResizingSelection;
                        _activeEdge = isPointOnEdge;
                    }
                    else
                    {
                        CurrentMode = BehaviorModeEnum.RequestMovingSelection;
                    }
                }
                else if (location.Y < _playHeadExtents.Height)
                {
                    CurrentMode = BehaviorModeEnum.TimeScrub;
                    SetClockFromMousePosition(location);
                }
                else
                {
                    if (!IsKeyDown(Keys.Control))
                    {
                        InvokeSelectionChanged(new SelectionChangedEventArgs(null, _selectedTracks));
                        _selectedTracks.Clear();
                    }

                    _selectionOrigin = location;

                    CurrentMode = BehaviorModeEnum.Selecting;
                }
            }
            else if ((e.Button & MouseButtons.Middle) != 0)
            {
                _panOrigin = location;
                _renderingOffsetBeforePan = _renderingOffset;
            }
            else if ((e.Button & MouseButtons.Right) != 0)
            {
                TimelineTrackBase focusedTrack = TrackHitTest(location);

                if (focusedTrack != null)
                {
                    InvokeSelectionChanged(new SelectionChangedEventArgs(focusedTrack.Yield(), null));

                    _selectedTracks.Clear();

                    _selectedTracks.Add(focusedTrack);

                    switch (focusedTrack.TimelineTrackType)
                    {
                        case TimelineTrackTypeEnum.AudioTrack:
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.Filter = @"Wav File|*.wav";
                            openFileDialog.Title = @"Open Wav File";
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                                LoadWaveFile(openFileDialog.FileName);
                            break;
                        case TimelineTrackTypeEnum.Phoneme:
                        case TimelineTrackTypeEnum.Expression:
                            _popupContextTrack = new PopupContextTrackValue(focusedTrack.Value, focusedTrack);
                            _popupContextContainer = new PopupContextContainer(_popupContextTrack);
                            _popupContextContainer.Show(this, focusedTrack, location);
                            break;
                        case TimelineTrackTypeEnum.Text:
                            _popupContextTrackText = new PopupContextTrackText(focusedTrack);
                            _popupContextContainer = new PopupContextContainer(_popupContextTrackText);
                            _popupContextContainer.Show(this, focusedTrack, location);
                            break;
                    }
                }
            }

            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Focus();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            PointF location = new PointF(e.X, e.Y);

            if ((e.Button & MouseButtons.Left) != 0)
            {
                switch (CurrentMode)
                {
                    case BehaviorModeEnum.Selecting:
                    {
                        int trackIndex = TrackLabelHitTest(location);
                        if (-1 < trackIndex)
                        {
                            TimelinePartBase part = _parts[trackIndex];

                            foreach (TimelineTrackBase trackElement in part.TrackElements)
                            {
                                if (_selectedTracks.Contains(trackElement))
                                {
                                    _selectedTracks.Remove(trackElement);
                                    InvokeSelectionChanged(new SelectionChangedEventArgs(null, trackElement.Yield()));
                                }
                                else
                                {
                                    _selectedTracks.Add(trackElement);
                                    InvokeSelectionChanged(new SelectionChangedEventArgs(trackElement.Yield(), null));
                                }
                            }
                        }
                        else
                        {
                            RectangleF selectionRectangle = RectangleHelper.Normalize(_selectionOrigin, location);

                            List<TimelineTrackBase> timelineTrackList = _parts.SelectMany(t => t.TrackElements).ToList();
                            foreach (TimelineTrackBase track in timelineTrackList)
                            {
                                int trackInd = TrackIndexForTrack(track);

                                RectangleF boundingRectangle = BoundsHelper.GetTrackExtents(track, this, trackInd);

                                if (SelectionHelper.IsSelected(selectionRectangle, boundingRectangle, ModifierKeys))
                                {
                                    if (_selectedTracks.Contains(track))
                                    {
                                        _selectedTracks.Remove(track);
                                        InvokeSelectionChanged(new SelectionChangedEventArgs(null, track.Yield()));
                                    }
                                    else
                                    {
                                        _selectedTracks.Add(track);
                                        InvokeSelectionChanged(new SelectionChangedEventArgs(track.Yield(), null));
                                    }
                                }
                            }
                        }

                        break;
                    }
                    case BehaviorModeEnum.MovingSelection:
                    case BehaviorModeEnum.ResizingSelection:
                    {
                        foreach (SurrogateTrack surrogate in _trackSurrogates.Cast<SurrogateTrack>())
                        {
                            surrogate.CopyTo(surrogate.SubstituteFor);
                        }

                        _trackSurrogates.Clear();

                        RecalculateScrollbarBounds();
                        break;
                    }
                }

                Cursor = Cursors.Arrow;
                _selectionOrigin = PointF.Empty;
                _selectionRectangle = RectangleF.Empty;
                CurrentMode = BehaviorModeEnum.Idle;
            }
            else if ((e.Button & MouseButtons.Middle) != 0)
            {
                _panOrigin = PointF.Empty;
                _renderingOffsetBeforePan = PointF.Empty;
            }

            Invalidate();
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            e.Effect = DragDropEffects.Copy;
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            PointF location = PointToClient(new Point(e.X, e.Y));

            TimelinePartBase part = PartTimelineHitTest(location);
            if (part != null)
            {
                if (e.Data.GetData(typeof(MorphTimelineTrack)) is MorphTimelineTrack morphTimelineTrack)
                {
                    Console.WriteLine(morphTimelineTrack.Name);

                    if (part.TimelineTrackType == morphTimelineTrack.TimelineTrackType)
                    {
                        Rectangle trackAreaBounds = GetTrackAreaBounds();
                        _renderingScale.X = Math.Max(0.01f, _renderingScale.X);

                        float locateX = (location.X - _renderingOffset.X - trackAreaBounds.X) * (1 / _renderingScale.X);

                        MorphTimelineTrack morphTrack = new MorphTimelineTrack(morphTimelineTrack.Name, locateX, locateX + morphTimelineTrack.End, morphTimelineTrack.Value, morphTimelineTrack.TimelineTrackType, morphTimelineTrack.Bitmap);

                        part.TrackElements.Add(morphTrack);

                        RecalculateScrollbarBounds();
                        Invalidate();
                    }
                }
            }

            Focus();
        }

        private void ScrollbarVScroll(object sender, ScrollEventArgs e)
        {
            _renderingOffset.Y = -e.NewValue;
            Invalidate();
        }

        private void ScrollbarHScroll(object sender, ScrollEventArgs e)
        {
            _renderingOffset.X = -e.NewValue;
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (IsKeyDown(Keys.Alt))
            {
                float amount = e.Delta / 120f;

                Rectangle trackAreaBounds = GetTrackAreaBounds();

                if (IsKeyDown(Keys.Control))
                {
                    _renderingScale.X += amount;
                    _renderingScale.X = Math.Max(1, _renderingScale.X);
                    _renderingOffset.X -= trackAreaBounds.Width * ((e.Location.X - trackAreaBounds.X) / (float) trackAreaBounds.Width) * amount;
                    _renderingOffset.X = Math.Min(0, _renderingOffset.X);
                    ScrollbarH.Value = (int) -_renderingOffset.X;
                }
                else
                {
                    _renderingScale.Y += amount;
                    _renderingScale.Y = Math.Max(1, _renderingScale.Y);
                    _renderingOffset.Y -= trackAreaBounds.Height * ((e.Location.Y - trackAreaBounds.Y) / (float) trackAreaBounds.Height) * amount;
                    _renderingOffset.Y = Math.Min(0, _renderingOffset.Y);
                    ScrollbarV.Value = (int) -_renderingOffset.Y;
                }

                RecalculateScrollbarBounds();
            }
            else
            {
                if (IsKeyDown(Keys.Control))
                    ScrollbarH.Value -= e.Delta / 10;
                else
                    ScrollbarV.Value -= e.Delta / 10;
            }

            Invalidate();
        }
    }
}
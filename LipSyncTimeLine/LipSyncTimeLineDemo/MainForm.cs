using LipSyncTimeLineControl.Events;
using LipSyncTimeLineControl.Models;
using LipSyncTimeLineControl.Template;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LipSyncTimeLineDemo
{
    public partial class MainForm : Form
    {
        private UdpAsyncSocket _udpAsyncSocket = new UdpAsyncSocket();

        public MainForm()
        {
            InitializeComponent();

            chbPlayingLoop.Checked = timeline.PlayingLoop;

            AudioTrackTimelineTrack audioTrackTimelineTrack = timeline.GetAudioTrackTimelineTrack();
            if (audioTrackTimelineTrack != null)
                nudTrackLength.Value = (decimal)(audioTrackTimelineTrack.End * 10f);

            phonemeListView.Items.Clear();

            expressionListBox.DisplayMember = "Name";
            foreach (ExpressionTimelineTrack expressionTemplate in ExpressionTemplate.ExpressionTrackTemplateDictionary.Values)
                expressionListBox.Items.Add(expressionTemplate);
            

            foreach (PhonemeTimelineTrack phonemeTemplate in PhonemeTemplate.PhonemeTrackTemplateDictionary.Values)
            {
                ListViewItem listViewItem = new ListViewItem
                {
                    Text = phonemeTemplate.Name, 
                    Tag = phonemeTemplate,
                    ImageKey = phonemeTemplate.Name
                };
                phonemeListView.Items.Add(listViewItem);
            }

            cbDevicesPlayer.Items.AddRange(timeline.GetDevicesPlayerArray());
            cbDevicesPlayer.SelectedIndex = 0;

            chbOnTop.Checked = TopMost;

            timeline.SelectionChanged += TimelineSelectionChanged;
            timeline.SoundPlayerTick += SoundPlayerTick;
        }

        private static void TimelineSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (selectionChangedEventArgs.Deselected != null)
                foreach (TimelineTrackBase track in selectionChangedEventArgs.Deselected)
                    Debug.WriteLine("Deselected: " + track);
            
            if (selectionChangedEventArgs.Selected != null)
                foreach (TimelineTrackBase track in selectionChangedEventArgs.Selected)
                    Debug.WriteLine("Selected: " + track);
        }

        private void SoundPlayerTick(object sender, SoundPlayerTickEventsArgs e)
        {
            Debug.WriteLine($"Elapsed Time: {e.ElapsedTime}");

            TimelineTrackBase track = timeline.GetCurrentPhonemeFromElapsedTime(e.ElapsedTime / 10);

            void Action() => btnPhonemeImage.BackgroundImage = track != null ? PhonemeTemplate.GetPhonemeImage(track.Name) : LipSyncTimeLineControl.Properties.Resources.Phoneme_None;

            if (InvokeRequired)
                Invoke((Action) Action);
            else
                Action();
        }

        private void expressionListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (expressionListBox.Items.Count == 0)
                return;

            int index = expressionListBox.IndexFromPoint(e.X, e.Y);
            if (index > -1)
                DoDragDrop(expressionListBox.Items[index], DragDropEffects.Copy);
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            timeline.NewProject();
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            timeline.OpenProject();
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            timeline.SaveProject();
        }

        private void btnAddSubtitleTrack_Click(object sender, EventArgs e)
        {
            timeline.AddSubtitleTrack();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            timeline.Export();
        }

        private void btnAddWordsTrack_Click(object sender, EventArgs e)
        {
            timeline.AddWordsTrack(rtbPhraseText.Text);
        }

        private void btnGeneratePhoneme_Click(object sender, EventArgs e)
        {
            timeline.GeneratePhoneme();
        }

        private void timeline_TimeChanged(object sender, TimeChangeEventsArgs e)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(e.Millisecond);
            toolStripStatusLabel1.Text = time.ToString("c");

            string jsonString = JsonConvert.SerializeObject(timeline.GetCurrentPartObjectList(e.Millisecond));

            _udpAsyncSocket.Send(jsonString);

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_udpAsyncSocket.UdpSocket == null || !_udpAsyncSocket.UdpSocket.IsBound || !_udpAsyncSocket.UdpSocket.Connected)
            {
                _udpAsyncSocket = new UdpAsyncSocket();
                _udpAsyncSocket.StartClient("127.0.0.1", Convert.ToInt32(tbUdpPort.Text));
            }
        }

        private void phonemeListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (phonemeListView.Items.Count == 0)
                return;

            Point localPoint = phonemeListView.PointToClient(Cursor.Position);
            ListViewItem item = phonemeListView.GetItemAt(localPoint.X, localPoint.Y);

            if (item != null)
                DoDragDrop(item, DragDropEffects.All);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            timeline.Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timeline.Pause();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timeline.Start();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            timeline.End();
        }

        private void chbPlayingLoop_CheckedChanged(object sender, EventArgs e)
        {
            timeline.PlayingLoop = chbPlayingLoop.Checked;
        }

        private void timeline_AudioTrackChanged(object sender, AudioTrackChangedEventsArgs e)
        {
            nudTrackLength.Value = (decimal)e.Millisecond;
        }

        private void nudTrackLength_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
                timeline.SetAudioTrackLength((float)numericUpDown.Value);
        }

        private void cbDevicesPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripComboBox toolStripComboBox)
                timeline.SetSelectDevicesPlayerIndex(toolStripComboBox.SelectedIndex);
        }

        private void chbOnTop_Click(object sender, EventArgs e)
        {

            if (sender is ToolStripButton toolStripButton)
            {
                toolStripButton.Checked = !toolStripButton.Checked;
                TopMost = toolStripButton.Checked;
            }
        }
    }
}

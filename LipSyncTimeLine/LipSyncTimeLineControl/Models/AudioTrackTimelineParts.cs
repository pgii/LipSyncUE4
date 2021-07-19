using System.Drawing;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class AudioTrackTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override Color BackColor { get; set; }
        public sealed override Color GradientColor { get; set; }
        public sealed override Color BorderColor { get; set; }

        public AudioTrackTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.AudioTrack;
            TrackElements.Add(new AudioTrackTimelineTrack("", 0, 700, true));
            BackColor = ColorTranslator.FromHtml("#BE3730");
            GradientColor = ColorTranslator.FromHtml("#EC5D59");
            BorderColor = ColorTranslator.FromHtml("#9F3936");
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
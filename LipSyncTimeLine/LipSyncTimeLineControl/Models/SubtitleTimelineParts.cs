using System.Drawing;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class SubtitleTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override Color BackColor { get; set; }
        public sealed override Color GradientColor { get; set; }
        public sealed override Color BorderColor { get; set; }

        public SubtitleTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.Subtitle;
            BackColor = ColorTranslator.FromHtml("#0045CC");
            GradientColor = ColorTranslator.FromHtml("#0085CC");
            BorderColor = ColorTranslator.FromHtml("#005299");
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
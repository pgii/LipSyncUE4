using System.Drawing;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class PhonemeTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override Color BackColor { get; set; }
        public sealed override Color GradientColor { get; set; }
        public sealed override Color BorderColor { get; set; }

        public PhonemeTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.Phoneme;
            BackColor = ColorTranslator.FromHtml("#51A451");
            GradientColor = ColorTranslator.FromHtml("#61C261");
            BorderColor = ColorTranslator.FromHtml("#448944");
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
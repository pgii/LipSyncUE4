using System.Drawing;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class WordsTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override Color BackColor { get; set; }
        public sealed override Color GradientColor { get; set; }
        public sealed override Color BorderColor { get; set; }

        public WordsTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.Words;
            BackColor = ColorTranslator.FromHtml("#3097B5");
            GradientColor = ColorTranslator.FromHtml("#59BEDC");
            BorderColor = ColorTranslator.FromHtml("#37839A");
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
using System.Drawing;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class ExpressionTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override Color BackColor { get; set; }
        public sealed override Color GradientColor { get; set; }
        public sealed override Color BorderColor { get; set; }

        public ExpressionTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.Expression;
            BackColor = ColorTranslator.FromHtml("#F39207");
            GradientColor = ColorTranslator.FromHtml("#FBB24C");
            BorderColor = ColorTranslator.FromHtml("#B67A24");
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
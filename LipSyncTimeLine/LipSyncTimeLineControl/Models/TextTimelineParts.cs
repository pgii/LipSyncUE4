using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class TextTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }

        public TextTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.Text;
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
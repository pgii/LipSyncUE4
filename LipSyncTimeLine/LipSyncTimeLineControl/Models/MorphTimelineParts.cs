using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class MorphTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }

        public MorphTimelineParts(string name, TimelineTrackTypeEnum timelineTrackType)
        {
            Name = name;
            TimelineTrackType = timelineTrackType;
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
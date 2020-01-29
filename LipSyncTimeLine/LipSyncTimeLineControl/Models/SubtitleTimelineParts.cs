using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class SubtitleTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }

        public SubtitleTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.Subtitle;
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
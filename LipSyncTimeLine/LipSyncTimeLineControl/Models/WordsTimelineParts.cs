using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class WordsTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }

        public WordsTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.Words;
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class AudioTrackTimelineTrack : TimelineTrackBase
    {
        public sealed override string Name { get; set; }
        public sealed override float Start { get; set; }
        public sealed override float End { get; set; }
        public sealed override float Value { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override bool IsLocked { get; set; }

        public AudioTrackTimelineTrack(string name, float start, float end, bool locked)
        {
            Name = name;
            Start = start;
            End = end;
            Value = 1;
            TimelineTrackType = TimelineTrackTypeEnum.AudioTrack;
            IsLocked = locked;
        }

        public override string ToString()
        {
            return $"Name: {Name}, End: {End}, Start: {Start}";
        }
    }
}
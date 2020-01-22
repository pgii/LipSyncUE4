using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class AudioTrackTimelineParts : TimelinePartBase
    {
        public sealed override string Name { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }

        public AudioTrackTimelineParts(string name)
        {
            Name = name;
            TimelineTrackType = TimelineTrackTypeEnum.AudioTrack;

            TrackElements.Add(new AudioTrackTimelineTrack("AudioTrack", 0, 700, true));
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
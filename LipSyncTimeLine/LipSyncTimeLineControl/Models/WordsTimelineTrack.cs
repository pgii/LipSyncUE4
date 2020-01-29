using System.Drawing;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    public class WordsTimelineTrack : TimelineTrackBase
    {
        public sealed override string Name { get; set; }
        public sealed override float Start { get; set; }
        public sealed override float End { get; set; }
        public sealed override float Value { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override bool IsLocked { get; set; }
        public sealed override Bitmap Bitmap { get; set; }

        public WordsTimelineTrack(string name, float start, float end)
        {
            Name = name;
            Start = start;
            End = end;
            Value = 0;
            TimelineTrackType = TimelineTrackTypeEnum.Words;
            IsLocked = false;
            Bitmap = null;
        }

        public override string ToString()
        {
            return $"Name: {Name}, End: {End}, Start: {Start}";
        }
    }
}
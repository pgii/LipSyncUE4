using LipSyncTimeLineControl.Enums;
using System;

namespace LipSyncTimeLineControl.Models
{
    public class ExpressionTimelineTrack : TimelineTrackBase, ICloneable
    {
        public sealed override string Name { get; set; }
        public sealed override float Start { get; set; }
        public sealed override float End { get; set; }
        public sealed override float Value { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override bool IsLocked { get; set; }

        public ExpressionTimelineTrack(string name, float start, float end, float defaultValue)
        {
            Name = name;
            Start = start;
            End = end;
            Value = defaultValue;
            TimelineTrackType = TimelineTrackTypeEnum.Expression;
            IsLocked = false;
        }

        public override string ToString()
        {
            return $"Name: {Name}, End: {End}, Start: {Start}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
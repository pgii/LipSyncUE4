using System.Drawing;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Models
{
    internal class SurrogateTrack : TimelineTrackBase
    {
        public TimelineTrackBase SubstituteFor { get; }
        public sealed override string Name { get; set; }
        public sealed override float Start { get; set; }
        public sealed override float End { get; set; }
        public sealed override float Value { get; set; }
        public sealed override TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public sealed override bool IsLocked { get; set; }
        public sealed override Bitmap Bitmap { get; set; }

        public SurrogateTrack(TimelineTrackBase substituteFor)
        {
            SubstituteFor = substituteFor;
            Start = substituteFor.Start;
            End = substituteFor.End;
            Name = substituteFor.Name;
            Value = substituteFor.Value;
            TimelineTrackType = substituteFor.TimelineTrackType;
            IsLocked = substituteFor.IsLocked;
            Bitmap = substituteFor.Bitmap;
        }

        public void CopyTo(TimelineTrackBase target)
        {
            target.Start = Start;
            target.End = End;
        }
    }
}
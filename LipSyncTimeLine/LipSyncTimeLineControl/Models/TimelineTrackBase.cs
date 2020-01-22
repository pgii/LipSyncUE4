using LipSyncTimeLineControl.Enums;
using System.Drawing;

namespace LipSyncTimeLineControl.Models
{
    public abstract class TimelineTrackBase
    {
        public abstract string Name { get; set; }
        public abstract float Start { get; set; }
        public abstract float End { get; set; }
        public abstract float Value { get; set; }
        public abstract TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public abstract bool IsLocked { get; set; }
        public abstract Bitmap Bitmap { get; set; }
    }
}
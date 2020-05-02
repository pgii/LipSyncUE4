using LipSyncTimeLineControl.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace LipSyncTimeLineControl.Models
{
    public abstract class TimelinePartBase
    {
        public  List<TimelineTrackBase> TrackElements = new List<TimelineTrackBase>();
        public abstract string Name { get; set; }
        public abstract TimelineTrackTypeEnum TimelineTrackType { get; set; }
        public abstract Color BackColor { get; set; }
        public abstract Color GradientColor { get; set; }
        public abstract Color BorderColor { get; set; }
    }
}
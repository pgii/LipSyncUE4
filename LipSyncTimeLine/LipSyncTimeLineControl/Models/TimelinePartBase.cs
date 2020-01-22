using LipSyncTimeLineControl.Enums;
using System.Collections.Generic;

namespace LipSyncTimeLineControl.Models
{
    public abstract class TimelinePartBase
    {
        public  List<TimelineTrackBase> TrackElements = new List<TimelineTrackBase>();
        public abstract string Name { get; set; }
        public abstract TimelineTrackTypeEnum TimelineTrackType { get; set; }
    }
}
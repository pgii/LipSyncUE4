using System;

namespace LipSyncTimeLineControl.Events
{
    public class TimeChangeEventsArgs : EventArgs
    {
        public float Millisecond { get; }
        public TimeChangeEventsArgs(float millisecond) => Millisecond = millisecond;
    }
}
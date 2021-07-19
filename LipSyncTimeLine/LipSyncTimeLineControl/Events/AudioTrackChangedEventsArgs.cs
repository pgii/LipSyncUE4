using System;

namespace LipSyncTimeLineControl.Events
{
    public class AudioTrackChangedEventsArgs : EventArgs
    {
        public float Millisecond { get; }
        public AudioTrackChangedEventsArgs(float millisecond) => Millisecond = millisecond;
    }
}
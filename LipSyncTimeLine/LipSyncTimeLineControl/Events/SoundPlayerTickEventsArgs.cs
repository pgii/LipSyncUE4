using System;

namespace LipSyncTimeLineControl.Events
{
    public class SoundPlayerTickEventsArgs : EventArgs
    {
        public double ElapsedTime { get; }
        public SoundPlayerTickEventsArgs(double elapsedTime) => ElapsedTime = elapsedTime;
    }
}
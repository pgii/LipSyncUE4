using System;

namespace LipSyncTimeLineControl.Events
{
    public class SoundPlayerTickEventsArgs : EventArgs
    {
        public double ElapsedTime { get; }
        public SoundPlayerTickEventsArgs(double elapsedTime)
        {
            ElapsedTime = elapsedTime;
        }

        public new static SoundPlayerTickEventsArgs Empty => new SoundPlayerTickEventsArgs(0);
    }
}
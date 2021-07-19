namespace LipSyncTimeLineControl.Utils
{
    public class LipSyncTimeLineClock
    {
        public float Value { get; set; }

        public bool IsRunning { get; private set; }

        public void Pause() => IsRunning = false;

        public void Play() => IsRunning = true;
    }
}

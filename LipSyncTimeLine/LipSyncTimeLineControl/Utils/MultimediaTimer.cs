using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace LipSyncTimeLineControl.Utils
{
    public class MultimediaTimer : IDisposable
    {
        private bool _disposed;
        private int _interval;
        private int _resolution;
        private uint _timerId;

        private readonly MultimediaTimerCallback _callback;

        public MultimediaTimer()
        {
            _callback = TimerCallbackMethod;
            Resolution = 5;
            Interval = 10;
        }

        ~MultimediaTimer() => Dispose(false);

        public int Interval
        {
            get => _interval;
            set
            {
                CheckDisposed();

                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _interval = value;
                if (Resolution > Interval)
                    Resolution = value;
            }
        }

        public int Resolution
        {
            get => _resolution;
            set
            {
                CheckDisposed();

                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _resolution = value;
            }
        }

        public bool IsRunning => _timerId != 0;

        public void Start()
        {
            CheckDisposed();

            if (IsRunning)
                return;

            uint userCtx = 0;

            _timerId = NativeMethods.TimeSetEvent((uint)Interval, (uint)Resolution, _callback, ref userCtx, 1);

            if (_timerId == 0)
            {
                int error = Marshal.GetLastWin32Error();
                throw new Win32Exception(error);
            }
        }

        public void Stop()
        {
            CheckDisposed();

            if (!IsRunning)
                return;

            StopInternal();
        }

        private void StopInternal()
        {
            NativeMethods.TimeKillEvent(_timerId);
            _timerId = 0;
        }

        public event EventHandler Elapsed;

        public void Dispose() => Dispose(true);

        private void TimerCallbackMethod(uint id, uint msg, ref uint userCtx, uint rsv1, uint rsv2)
        {
            EventHandler handler = Elapsed;
            handler?.Invoke(this, EventArgs.Empty);
        }

        private void CheckDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("MultimediaTimer");
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _disposed = true;
            if (IsRunning)
            {
                StopInternal();
            }

            if (disposing)
            {
                Elapsed = null;
                GC.SuppressFinalize(this);
            }
        }
    }

    internal delegate void MultimediaTimerCallback(uint id, uint msg, ref uint userCtx, uint rsv1, uint rsv2);

    internal static class NativeMethods
    {
        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeSetEvent")]
        internal static extern uint TimeSetEvent(uint msDelay, uint msResolution, MultimediaTimerCallback callback, ref uint userCtx, uint eventType);

        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeKillEvent")]
        internal static extern void TimeKillEvent(uint uTimerId);
    }
}

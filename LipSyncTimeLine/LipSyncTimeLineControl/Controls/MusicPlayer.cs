using System;
using System.ComponentModel;
using CSCore;
using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;

namespace LipSyncTimeLineControl.Controls
{
    public class MusicPlayer : Component
    {
        private ISoundOut _soundOut;
        private IWaveSource _waveSource;

        public event EventHandler<PlaybackStoppedEventArgs> PlaybackStopped;

        public TimeSpan Position
        {
            get => _waveSource?.GetPosition() ?? TimeSpan.Zero;
            set => _waveSource?.SetPosition(value);
        }

        public TimeSpan Length => _waveSource?.GetLength() ?? TimeSpan.Zero;

        public void Open(string filename, MMDevice device)
        {
            CleanupPlayback();

            _waveSource = CodecFactory.Instance.GetCodec(filename)
                .ToSampleSource()
                .ToMono()
                .ToWaveSource();

            _soundOut = new WasapiOut {Latency = 100, Device = device};
            _soundOut.Initialize(_waveSource);

            if (PlaybackStopped != null) 
                _soundOut.Stopped += PlaybackStopped;
        }

        public void Play() => _soundOut?.Play();

        public void Stop() => _soundOut?.Stop();

        private void CleanupPlayback()
        {
            if (_soundOut != null)
            {
                _soundOut.Dispose();
                _soundOut = null;
            }

            if (_waveSource != null)
            {
                _waveSource.Dispose();
                _waveSource = null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            CleanupPlayback();
        }
    }
}
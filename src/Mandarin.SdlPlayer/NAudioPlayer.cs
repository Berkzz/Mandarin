using System.Security.Cryptography.X509Certificates;
using Mandarin.Core.Interfaces.Audio;
using NAudio.Wave;

namespace Mandarin.NAudioPlayer;

public class NAudioPlayer : IAudioPlayer
{
    private readonly WaveOutEvent _outputDevice;
    private AudioFileReader? _audioFileReader;

    public NAudioPlayer()
    {
        _outputDevice = new WaveOutEvent();
        _outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
    }

    public void Pause()
    {
        _outputDevice.Pause();
    }

    public float Volume
    {
        set
        {
            if (value is < 0 or > 1)
            {
                return;
            }

            _outputDevice.Volume = value;
        }

        get => _outputDevice.Volume;
    }

    public void Play(string audioLocation)
    {
        _audioFileReader ??= new AudioFileReader(audioLocation);

        _outputDevice.Init(_audioFileReader);
        _outputDevice.Play();
    }

    public void Stop()
    {
        _outputDevice.Stop();
    }

    private void OutputDevice_PlaybackStopped(object? sender, StoppedEventArgs e)
    {
        _audioFileReader?.Dispose();
    }
}
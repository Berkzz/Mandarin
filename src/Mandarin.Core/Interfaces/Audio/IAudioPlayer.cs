namespace Mandarin.Core.Interfaces.Audio;

public interface IAudioPlayer
{
    public void Play(string audioLocation);
    public void Stop();
    public void Pause();
    public  float Volume { get; set; }
}
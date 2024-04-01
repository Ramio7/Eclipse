using System;

public interface IGameSettings : IDisposable
{
    public float MasterVolume { get; set; }
    public float SoundVolume { get; set; }
    public float MusicVolume { get; set; }
    public float BrightnessVolume { get; set; }
    public float EffectVolume { get; set; }
    public float VoiceVolume { get; set; }
    public float ContrastRatio { get; set; }
    public bool IsSubtitlesOn {  get; set; }
}

using System;

public struct GameSettings : IDisposable
{
    public float MasterVolume;
    public float SoundVolume;
    public float MusicVolume;
    public float BrightnessVolume;
    public float EffectVolume;
    public float VoiceVolume;
    public float ContrastRatio;
    public bool IsSubtitlesOn;

    public GameSettings(float masterVolume, float soundVolume, float musicVolume, float brightnessVolume,
        float effectVolume, float voiceVolume, float contrastRatio, bool isSubtitlesOn)
    {
        MasterVolume = masterVolume;
        SoundVolume = soundVolume;
        MusicVolume = musicVolume;
        BrightnessVolume = brightnessVolume;
        EffectVolume = effectVolume;
        VoiceVolume = voiceVolume;
        ContrastRatio = contrastRatio;
        IsSubtitlesOn = isSubtitlesOn;
    }

    public void Dispose()
    {
        MasterVolume = 0f;
        SoundVolume = 0;
        MusicVolume = 0;
        BrightnessVolume = 0;
        EffectVolume = 0;
        VoiceVolume = 0;
        ContrastRatio = 0;
        IsSubtitlesOn = false;
    }

    public readonly bool IsEqual(GameSettings other)
    {
        return other.MasterVolume == MasterVolume && other.SoundVolume == SoundVolume
            && other.MusicVolume == MusicVolume && other.BrightnessVolume == BrightnessVolume
            && other.EffectVolume == EffectVolume && other.VoiceVolume == VoiceVolume
            && other.ContrastRatio == ContrastRatio && other.IsSubtitlesOn == IsSubtitlesOn;
    }
}

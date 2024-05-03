using System;

[Serializable]
public struct GameSettings : IDisposable
{
    public float MasterVolume;
    public float SoundVolume;
    public float MusicVolume;
    public float EffectVolume;
    public float VoiceVolume;
    public float ContrastRatio;
    public float BrightnessVolume;
    public bool IsSubtitlesOn;

    public void Set(float masterVolume, float soundVolume, float musicVolume, float brightnessVolume,
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

    public void Set(GameSettings gameSettings)
    {
        MasterVolume = gameSettings.MasterVolume;
        SoundVolume = gameSettings.SoundVolume;
        MusicVolume = gameSettings.MusicVolume;
        BrightnessVolume = gameSettings.BrightnessVolume;
        EffectVolume = gameSettings.EffectVolume;
        VoiceVolume = gameSettings.VoiceVolume;
        ContrastRatio = gameSettings.ContrastRatio;
        IsSubtitlesOn = gameSettings.IsSubtitlesOn;
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

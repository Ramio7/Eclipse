using System;
using UnityEngine;

[Serializable]
public struct GameSettings : IDisposable
{
    [Range(0f, 1f)] public float MasterVolume;
    [Range(0f, 1f)] public float SoundVolume;
    [Range(0f, 1f)] public float MusicVolume;
    [Range(0f, 1f)] public float EffectVolume;
    [Range(0f, 1f)] public float VoiceVolume;
    [Range(0f, 1f)] public float ContrastRatio;
    [Range(0f, 1f)] public float BrightnessVolume;
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

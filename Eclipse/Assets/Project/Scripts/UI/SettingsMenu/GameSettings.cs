using System;
using UnityEngine;

[Serializable]
public struct GameSettings : IGameSettings
{
    [Range(0f, 1f)] private float _masterVolume;
    [Range(0f, 1f)] private float _soundVolume;
    [Range(0f, 1f)] private float _musicVolume;
    [Range(0f, 1f)] private float _effectVolume;
    [Range(0f, 1f)] private float _voiceVolume;
    [Range(0f, 1f)] private float _contrastRatio;
    [Range(0f, 1f)] private float _brightnessVolume;
    private bool _isSubtitlesOn;

    public float MasterVolume { get => _masterVolume; set => _masterVolume = value; }
    public float SoundVolume { get => _soundVolume; set => _soundVolume = value; }
    public float MusicVolume { get => _musicVolume; set => _musicVolume = value; }
    public float BrightnessVolume { get => _brightnessVolume; set => _brightnessVolume = value; }
    public float EffectVolume { get => _effectVolume; set => _effectVolume = value; }
    public float VoiceVolume { get => _voiceVolume; set => _voiceVolume = value; }
    public float ContrastRatio { get => _contrastRatio; set => _contrastRatio = value   ; }
    public bool IsSubtitlesOn { get => _isSubtitlesOn; set => _isSubtitlesOn = value; }

    public void Set(float masterVolume, float soundVolume, float musicVolume, float brightnessVolume,
        float effectVolume, float voiceVolume, float contrastRatio, bool isSubtitlesOn)
    {
        _masterVolume = masterVolume;
        _soundVolume = soundVolume;
        _musicVolume = musicVolume;
        _brightnessVolume = brightnessVolume;
        _effectVolume = effectVolume;
        _voiceVolume = voiceVolume;
        _contrastRatio = contrastRatio;
        _isSubtitlesOn = isSubtitlesOn;
    }

    public void Set(GameSettings gameSettings)
    {
        _masterVolume = gameSettings.MasterVolume;
        _soundVolume = gameSettings.SoundVolume;
        _musicVolume = gameSettings.MusicVolume;
        _brightnessVolume = gameSettings.BrightnessVolume;
        _effectVolume = gameSettings.EffectVolume;
        _voiceVolume = gameSettings.VoiceVolume;
        _contrastRatio = gameSettings.ContrastRatio;
        _isSubtitlesOn = gameSettings.IsSubtitlesOn;
    }

    public void Dispose()
    {
        _masterVolume = 0f;
        _soundVolume = 0;
        _musicVolume = 0;
        _brightnessVolume = 0;
        _effectVolume = 0;
        _voiceVolume = 0;
        _contrastRatio = 0;
        _isSubtitlesOn = false;
    }

    public readonly bool IsEqual(GameSettings other)
    {
        return other.MasterVolume == _masterVolume && other.SoundVolume == _soundVolume
            && other._musicVolume == _musicVolume && other._brightnessVolume == _brightnessVolume
            && other._effectVolume == _effectVolume && other._voiceVolume == _voiceVolume
            && other._contrastRatio == _contrastRatio && other._isSubtitlesOn == _isSubtitlesOn;
    }
}

using System;
using System.IO;
using UnityEngine;

public class SettingsMenuModel : BaseModel
{
    private GameSettings _gameSettings = new();

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/settings.json";

    public ReactiveProperty<bool> SettingsIsChanged = new(false);

    public SettingsMenuModel(SettingsMenuScriptableObject defaults) : base()
    {
        if (!CheckSettingsFile())
        {
            _gameSettings.MasterVolume = defaults.MasterVolume;
            _gameSettings.SoundVolume = defaults.DefaultSoundVolume;
            _gameSettings.MusicVolume = defaults.DefaultMusicVolume;
            _gameSettings.BrightnessVolume = defaults.DefaultBrightnessVolume;
            _gameSettings.EffectVolume = defaults.DefaultEffectVolume;
            _gameSettings.VoiceVolume = defaults.DefaultVoiceVolume;
            _gameSettings.ContrastRatio = defaults.DefaultContrastRatio;
            _gameSettings.IsSubtitlesOn = defaults.DefaultIsSubtitlesOn;
            Debug.Log(CreateSettingsFile());
        }
        else
        {
            LoadSettings();
        }
    }

    public override void Dispose()
    {
        _gameSettings.Dispose();
    }

    private bool CheckSettingsFile() => File.Exists(_settingsFilePath);

    private bool CreateSettingsFile()
    {
        var file = File.Create(_settingsFilePath);
        file.Close();
        SaveSettings();
        return File.Exists(_settingsFilePath);
    }

    public bool SaveSettings()
    {
        var settingsToJson = new JsonData<GameSettings>();
        settingsToJson.Save(_gameSettings, _settingsFilePath);
        SettingsIsChanged.SetValue(false);
        return _gameSettings.IsEqual(settingsToJson.Load(_settingsFilePath));
    }

    private bool LoadSettings()
    {
        var settingsToJson = new JsonData<GameSettings>();
        _gameSettings = settingsToJson.Load(_settingsFilePath);
        return settingsToJson.Load(_settingsFilePath).IsEqual(_gameSettings);
    }

    public void ChangeSoundVolume(float volume)
    {
        _gameSettings.SoundVolume = volume;
        SettingsIsChanged.SetValue(true);
    }

    public void ChangeMusicVolume(float volume)
    {
        _gameSettings.MusicVolume = volume;
        SettingsIsChanged.SetValue(true);
    }

    public void ChangeBrightnessVolume(float volume)
    {
        _gameSettings.BrightnessVolume = volume;
        SettingsIsChanged.SetValue(true);
    }

    public void ChangeEffectVolume(float volume)
    {
        _gameSettings.EffectVolume = volume;
        SettingsIsChanged.SetValue(true);
    }

    public void ChangeVoiceVolume(float volume)
    {
        _gameSettings.VoiceVolume = volume;
        SettingsIsChanged.SetValue(true);
    }

    public void ChangeContrastRatio(float volume)
    {
        _gameSettings.ContrastRatio = volume;
        SettingsIsChanged.SetValue(true);
    }

    public void ChangeMasterSoundVolume(float volume)
    {
        _gameSettings.MasterVolume = volume;
        SettingsIsChanged.SetValue(true);
    }

    public void ChangeSubtitlesOnOff(bool isOn)
    {
        _gameSettings.IsSubtitlesOn = isOn;
        SettingsIsChanged.SetValue(true);
    }

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

        public bool IsEqual(GameSettings other)
        {
            return other.MasterVolume == MasterVolume && other.SoundVolume == SoundVolume 
                && other.MusicVolume == MusicVolume && other.BrightnessVolume == BrightnessVolume
                && other.EffectVolume == EffectVolume && other.VoiceVolume == VoiceVolume 
                && other.ContrastRatio == ContrastRatio && other.IsSubtitlesOn == IsSubtitlesOn;
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
    }
}
    
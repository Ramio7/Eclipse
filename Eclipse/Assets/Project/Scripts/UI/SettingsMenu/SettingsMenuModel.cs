using System.IO;
using UnityEngine;

public class SettingsMenuModel : BaseModel
{
    private GameSettings _gameSettings;

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/settings.json";

    public ReactiveProperty<bool> SettingsIsSaved = new(false);
    public GameSettings GameSettings { get => _gameSettings; set => _gameSettings = value; }

    public SettingsMenuModel(SettingsMenuScriptableObject defaults) : base()
    {
        if (!CheckSettingsFile())
        {
            _gameSettings = new(defaults.MasterVolume, defaults.DefaultSoundVolume, defaults.DefaultMusicVolume, defaults.DefaultBrightnessVolume,
                defaults.DefaultEffectVolume, defaults.DefaultVoiceVolume, defaults.DefaultContrastRatio, defaults.DefaultIsSubtitlesOn);
            Debug.Log($"Settings file status is {CreateSettingsFile()}");
            SaveSettings();
        }
        else
        {
            Debug.Log($"Settings file is loaded: {LoadSettings()}");
        }
    }

    public override void Dispose()
    {
        SettingsIsSaved.Dispose();
        GameSettings.Dispose();

        _settingsFilePath = null;
    }

    private bool CheckSettingsFile() => File.Exists(_settingsFilePath);

    private bool CreateSettingsFile()
    {
        var file = File.Create(_settingsFilePath);
        file.Close();
        return File.Exists(_settingsFilePath);
    }

    public void SaveSettings()
    {
        JsonData<GameSettings>.Save(_gameSettings, _settingsFilePath);
        SettingsIsSaved.SetValue(true);
        //Debug.Log($"Settings file is updated: {_gameSettings.IsEqual(settingsToJson.Load(_settingsFilePath))}");
    }

    private bool LoadSettings()
    {
        var tempgameSettings = JsonData<GameSettings>.Load(_settingsFilePath);
        _gameSettings = new(tempgameSettings.MasterVolume, tempgameSettings.SoundVolume, tempgameSettings.MusicVolume, tempgameSettings.BrightnessVolume,
            tempgameSettings.EffectVolume, tempgameSettings.VoiceVolume, tempgameSettings.ContrastRatio, tempgameSettings.IsSubtitlesOn);
        return tempgameSettings.IsEqual(_gameSettings);
    }

    public void ChangeSoundVolume(float volume)
    {
        _gameSettings.SoundVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeMusicVolume(float volume)
    {
        _gameSettings.MusicVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeBrightnessVolume(float volume)
    {
        _gameSettings.BrightnessVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeEffectVolume(float volume)
    {
        _gameSettings.EffectVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeVoiceVolume(float volume)
    {
        _gameSettings.VoiceVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeContrastRatio(float volume)
    {
        _gameSettings.ContrastRatio = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeMasterVolume(float volume)
    {
        _gameSettings.MasterVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeSubtitlesOnOff(bool isOn)
    {
        _gameSettings.IsSubtitlesOn = isOn;
        SettingsIsSaved.SetValue(false);
    }
}
    
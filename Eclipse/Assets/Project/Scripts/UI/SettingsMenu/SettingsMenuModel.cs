using System.IO;
using UnityEngine;

public class SettingsMenuModel : BaseModel
{
    private GameSettings _gameSettings;

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/settings.json";

    public ReactiveProperty<bool> SettingsIsChanged = new(false);
    public GameSettings GameSettings { get => _gameSettings; set => _gameSettings = value; }

    public SettingsMenuModel(SettingsMenuScriptableObject defaults) : base()
    {
        if (!CheckSettingsFile())
        {
            _gameSettings = new(defaults.MasterVolume, defaults.DefaultSoundVolume, defaults.DefaultMusicVolume, defaults.DefaultBrightnessVolume,
                defaults.DefaultEffectVolume, defaults.DefaultVoiceVolume, defaults.DefaultContrastRatio, defaults.DefaultIsSubtitlesOn);
            Debug.Log(CreateSettingsFile());
        }
        else
        {
            LoadSettings();
        }
    }

    public override void Dispose()
    {
        SettingsIsChanged.Dispose();
        GameSettings.Dispose();

        _settingsFilePath = null;
    }

    private bool CheckSettingsFile() => File.Exists(_settingsFilePath);

    private bool CreateSettingsFile()
    {
        var file = File.Create(_settingsFilePath);
        file.Close();
        SaveSettings();
        return File.Exists(_settingsFilePath);
    }

    public void SaveSettings()
    {
        var settingsToJson = new JsonData<GameSettings>();
        settingsToJson.Save(_gameSettings, _settingsFilePath);
        SettingsIsChanged.SetValue(false);
        Debug.Log(_gameSettings.IsEqual(settingsToJson.Load(_settingsFilePath)));
    }

    private bool LoadSettings()
    {
        var settingsToJson = new JsonData<GameSettings>();
        var tempgameSettings = settingsToJson.Load(_settingsFilePath);
        _gameSettings = new(tempgameSettings.MasterVolume, tempgameSettings.SoundVolume, tempgameSettings.MusicVolume, tempgameSettings.BrightnessVolume,
            tempgameSettings.EffectVolume, tempgameSettings.VoiceVolume, tempgameSettings.ContrastRatio, tempgameSettings.IsSubtitlesOn);
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

    public void ChangeMasterVolume(float volume)
    {
        _gameSettings.MasterVolume = volume;
        SettingsIsChanged.SetValue(true);
    }

    public void ChangeSubtitlesOnOff(bool isOn)
    {
        _gameSettings.IsSubtitlesOn = isOn;
        SettingsIsChanged.SetValue(true);
    }
}
    
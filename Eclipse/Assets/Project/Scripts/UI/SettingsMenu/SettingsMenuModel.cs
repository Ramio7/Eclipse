using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SettingsMenuModel : BaseModel
{
    private GameSettings _savedSettings = new();
    private GameSettings _tempSettings = new();

    private VolumeProfile _graphicsVolume;
    private AudioMixer _mixer;

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/settings.json";

    public ReactiveProperty<bool> SettingsIsSaved = new(false);
    public GameSettings GameSettings { get => _savedSettings; set => _savedSettings = value; }

    public SettingsMenuModel(SettingsMenuScriptableObject defaults) : base()
    {
        FindGraphicsVolumeAndAudioMixer();
        if (!CheckSettingsFile())
        {
            _savedSettings.Set(defaults.MasterVolume, defaults.DefaultSoundVolume, defaults.DefaultMusicVolume, defaults.DefaultBrightnessVolume,
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
        JsonData<GameSettings>.Save(_tempSettings, _settingsFilePath);
        SettingsIsSaved.SetValue(true);
        _savedSettings.Set(_tempSettings);
        //Debug.Log($"Settings file is updated: {_savedSettings.IsEqual(settingsToJson.Load(_settingsFilePath))}");
    }

    private bool LoadSettings()
    {
        var tempgameSettings = JsonData<GameSettings>.Load(_settingsFilePath);
        _savedSettings.Set(tempgameSettings.MasterVolume, tempgameSettings.SoundVolume, tempgameSettings.MusicVolume, tempgameSettings.BrightnessVolume,
            tempgameSettings.EffectVolume, tempgameSettings.VoiceVolume, tempgameSettings.ContrastRatio, tempgameSettings.IsSubtitlesOn);
        return tempgameSettings.IsEqual(_savedSettings);
    }

    public void ChangeSoundVolume(float volume)
    {
        _tempSettings.SoundVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeMusicVolume(float volume)
    {
        _tempSettings.MusicVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeBrightnessVolume(float volume)
    {
        _tempSettings.BrightnessVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeEffectVolume(float volume)
    {
        _tempSettings.EffectVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeVoiceVolume(float volume)
    {
        _tempSettings.VoiceVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeContrastRatio(float volume)
    {
        _tempSettings.ContrastRatio = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeMasterVolume(float volume)
    {
        _tempSettings.MasterVolume = volume;
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeSubtitlesOnOff(bool isOn)
    {
        _tempSettings.IsSubtitlesOn = isOn;
        SettingsIsSaved.SetValue(false);
    }

    private void FindGraphicsVolumeAndAudioMixer()
    {
        _graphicsVolume = EntryPointView.Instance.VolumeProfile;
        _mixer = EntryPointView.Instance.AudioMixer;
    }

    public void AutoUpdateSettings(bool settingsIsSaved)
    {
        if (settingsIsSaved)
        {
            EntryPointView.OnUpdate -= UpdateSettings;
        }
        else
        {
            EntryPointView.OnUpdate += UpdateSettings;
        }
    }

    private void UpdateSettings()
    {
        UpdateAudioMixer();
        UpdateVolumeProfile();
    }

    private void UpdateAudioMixer()
    {
        _mixer.SetFloat("MasterVolume", GameSettings.MasterVolume);
        _mixer.SetFloat("MusicVolume", GameSettings.MusicVolume);
        _mixer.SetFloat("VoiceVolume", GameSettings.VoiceVolume);
        _mixer.SetFloat("SoundVolume", GameSettings.SoundVolume);
        _mixer.SetFloat("EffectVolume", GameSettings.EffectVolume);
    }

    private void UpdateVolumeProfile()
    {

    }
}
    
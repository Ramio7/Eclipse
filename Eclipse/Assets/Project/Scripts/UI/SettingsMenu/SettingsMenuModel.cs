using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsMenuModel : BaseModel, IUIModel
{
    private GameState _gameState = GameState.SettingsMenu;

    private GameSettings _savedSettings = new();
    private GameSettings _tempSettings = new();

    private Volume _graphicsVolume;
    private AudioMixer _mixer;    

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/settings.json";

    public ReactiveProperty<bool> SettingsIsSaved = new(true);

    public GameSettings GameSettings { get => _savedSettings; }

    public SettingsMenuModel(IScriptableObject defaultSettings, Canvas settingsMenuCanvas) : base()
    {
        CanvasSelector.AddCanvas(_gameState, settingsMenuCanvas);
        var defaults = defaultSettings as SettingsMenuScriptableObject;
        GetGraphicsConponentAndAudioMixer();
        InitGameSettings(defaults);
    }

    public override void Dispose()
    {
        DiscardSettings();
        SettingsIsSaved.Dispose();
        GameSettings.Dispose();
        _tempSettings.Dispose();

        _mixer = null;
        _graphicsVolume = null;
        _settingsFilePath = null;
        SettingsIsSaved = null;
    }

    private void GetGraphicsConponentAndAudioMixer()
    {
        _mixer = EntryPointView.Instance.AudioMixer;
        _graphicsVolume = EntryPointView.Instance.VolumeProfile;
    }

    private void InitGameSettings(SettingsMenuScriptableObject defaults)
    {
        if (!CheckSettingsFile())
        {
            _savedSettings.Set(defaults.MasterVolume, defaults.DefaultSoundVolume, defaults.DefaultMusicVolume, defaults.DefaultBrightnessVolume,
                defaults.DefaultEffectVolume, defaults.DefaultVoiceVolume, defaults.DefaultContrastRatio, defaults.DefaultIsSubtitlesOn);
            _tempSettings.Set(defaults.MasterVolume, defaults.DefaultSoundVolume, defaults.DefaultMusicVolume, defaults.DefaultBrightnessVolume,
                defaults.DefaultEffectVolume, defaults.DefaultVoiceVolume, defaults.DefaultContrastRatio, defaults.DefaultIsSubtitlesOn);
            Debug.Log($"Settings file status is {CreateSettingsFile()}");
            SaveSettings();
        }
        else
        {
            Debug.Log($"Settings file is loaded: {LoadSettings()}");
        }
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
        _savedSettings.Set(_tempSettings);
        SettingsIsSaved.SetValue(true);
    }

    private bool LoadSettings()
    {
        var tempgameSettings = JsonData<GameSettings>.Load(_settingsFilePath);
        _savedSettings.Set(tempgameSettings.MasterVolume, tempgameSettings.SoundVolume, tempgameSettings.MusicVolume, tempgameSettings.BrightnessVolume,
            tempgameSettings.EffectVolume, tempgameSettings.VoiceVolume, tempgameSettings.ContrastRatio, tempgameSettings.IsSubtitlesOn);
        return tempgameSettings.IsEqual(_savedSettings);
    }

    public void DiscardSettings()
    {
        _mixer.SetFloat("SoundVolume", Mathf.Log10(GameSettings.SoundVolume) * 20);
        _mixer.SetFloat("MusicVolume", Mathf.Log10(GameSettings.MusicVolume) * 20);
        _mixer.SetFloat("EffectVolume", Mathf.Log10(GameSettings.EffectVolume) * 20);
        _mixer.SetFloat("VoiceVolume", Mathf.Log10(GameSettings.VoiceVolume) * 20);
        _mixer.SetFloat("MasterVolume", Mathf.Log10(GameSettings.MasterVolume) * 20);
        if (_graphicsVolume.sharedProfile.TryGet<ColorAdjustments>(out var colorAdj))
        {
            colorAdj.postExposure.Override(GameSettings.BrightnessVolume);
            colorAdj.contrast.Override(GameSettings.ContrastRatio);
        }
        else Debug.LogWarning("No color adjustments component found");
        _tempSettings.Set(GameSettings);
        SettingsIsSaved.SetValue(true);
    }

    public void ChangeSoundVolume(float volume)
    {
        _tempSettings.SoundVolume = volume;
        _mixer.SetFloat("SoundVolume", Mathf.Log10(_tempSettings.SoundVolume) * 20);
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeMusicVolume(float volume)
    {
        _tempSettings.MusicVolume = volume;
        _mixer.SetFloat("MusicVolume", Mathf.Log10(_tempSettings.MusicVolume) * 20);
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeBrightnessVolume(float volume)
    {
        _tempSettings.BrightnessVolume = volume;
        if (_graphicsVolume.sharedProfile.TryGet<ColorAdjustments>(out var colorAdj))
            colorAdj.postExposure.Override(volume);
        else Debug.LogWarning("No color adjustments component found");
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeEffectVolume(float volume)
    {
        _tempSettings.EffectVolume = volume;
        _mixer.SetFloat("EffectVolume", Mathf.Log10(_tempSettings.EffectVolume) * 20);
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeVoiceVolume(float volume)
    {
        _tempSettings.VoiceVolume = volume;
        _mixer.SetFloat("VoiceVolume", Mathf.Log10(_tempSettings.VoiceVolume) * 20);
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeContrastRatio(float volume)
    {
        _tempSettings.ContrastRatio = volume;
        if (_graphicsVolume.sharedProfile.TryGet<ColorAdjustments>(out var colorAdj)) 
            colorAdj.contrast.Override(volume);
        else Debug.LogWarning("No color adjustments component found");
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeMasterVolume(float volume)
    {
        _tempSettings.MasterVolume = volume;
        _mixer.SetFloat("MasterVolume", Mathf.Log10(_tempSettings.MasterVolume) * 20);
        SettingsIsSaved.SetValue(false);
    }

    public void ChangeSubtitlesOnOff(bool isOn)
    {
        _tempSettings.IsSubtitlesOn = isOn;
        SettingsIsSaved.SetValue(false);
    }
}
    
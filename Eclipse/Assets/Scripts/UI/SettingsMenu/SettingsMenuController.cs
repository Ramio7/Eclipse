using UnityEngine;
using UnityEngine.Rendering;

public class SettingsMenuController : BaseController
{
    private new SettingsMenuView _view;
    private new SettingsMenuModel _model;

    private Volume _imageVolume;
    private AudioSource _audioSource;

    public SettingsMenuController(SettingsMenuView view, SettingsMenuScriptableObject settingsDefaults) : base(view)
    {
        _view = view;
        _model = new(settingsDefaults);
        Init();
    }

    public override void Init()
    {
        base.Init();

        FindGlobalVolumeAndAudioSource();
        InitButtons();
    }

    public override void Dispose()
    {
        base.Dispose();

        DeinitButtons();

        _model.Dispose();

        _view = null;
        _model = null;
        _audioSource = null;
        _imageVolume = null;
    }

    private void FindGlobalVolumeAndAudioSource()
    {
        var tempGO = GameObject.Find("Global Volume");
        Object.DontDestroyOnLoad(tempGO);
        _imageVolume = tempGO.GetComponent<Volume>();
        _audioSource = tempGO.GetComponent<AudioSource>();
    }

    private void InitButtons()
    {
        _view.SaveSettingsButton.interactable = _model.SettingsIsChanged;

        _view.BrightnessVolumeSlider.onValueChanged.AddListener(_model.ChangeBrightnessVolume);
        _view.ContrastRatioSlider.onValueChanged.AddListener(_model.ChangeContrastRatio);
        _view.EffectVolumeSlider.onValueChanged.AddListener(_model.ChangeEffectVolume);
        _view.MasterSoundVolumeSlider.onValueChanged.AddListener(_model.ChangeMasterSoundVolume);
        _view.MusicVolumeSlider.onValueChanged.AddListener(_model.ChangeMusicVolume);
        _view.SoundVolumeSlider.onValueChanged.AddListener(_model.ChangeMusicVolume);
        _view.VoiceVolumeSlider.onValueChanged.AddListener(_model.ChangeVoiceVolume);
        _view.SubtitlesToogle.onValueChanged.AddListener(_model.ChangeSubtitlesOnOff);
    }

    private void DeinitButtons()
    {
        _view.BrightnessVolumeSlider.onValueChanged.RemoveListener(_model.ChangeBrightnessVolume);
        _view.ContrastRatioSlider.onValueChanged.RemoveListener(_model.ChangeContrastRatio);
        _view.EffectVolumeSlider.onValueChanged.RemoveListener(_model.ChangeEffectVolume);
        _view.MasterSoundVolumeSlider.onValueChanged.RemoveListener(_model.ChangeMasterSoundVolume);
        _view.MusicVolumeSlider.onValueChanged.RemoveListener(_model.ChangeMusicVolume);
        _view.SoundVolumeSlider.onValueChanged.RemoveListener(_model.ChangeMusicVolume);
        _view.VoiceVolumeSlider.onValueChanged.RemoveListener(_model.ChangeVoiceVolume);
        _view.SubtitlesToogle.onValueChanged.RemoveListener(_model.ChangeSubtitlesOnOff);
    }
}

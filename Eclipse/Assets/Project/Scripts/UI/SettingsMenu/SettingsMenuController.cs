public class SettingsMenuController : BaseController
{
    private new SettingsMenuView _view;
    private new SettingsMenuModel _model;

    public SettingsMenuController(SettingsMenuView view, SettingsMenuScriptableObject settingsDefaults) : base(view)
    {
        _view = view;
        _model = new(settingsDefaults);

        Init();
    }

    public override void Init()
    {
        base.Init();

        SetButtonsVolumes();
        InitButtons();
        InitActions();
    }

    public override void Dispose()
    {
        base.Dispose();

        DeinitButtons();
        DeInitActions();

        _model.Dispose();

        _view = null;
        _model = null;
    }


    private void SetButtonsVolumes()
    {
        _view.BrightnessVolumeSlider.SetValueWithoutNotify(_model.GameSettings.BrightnessVolume);
        _view.ContrastRatioSlider.SetValueWithoutNotify(_model.GameSettings.ContrastRatio);
        _view.EffectVolumeSlider.SetValueWithoutNotify(_model.GameSettings.EffectVolume);
        _view.MasterVolumeSlider.SetValueWithoutNotify(_model.GameSettings.MasterVolume);
        _view.MusicVolumeSlider.SetValueWithoutNotify(_model.GameSettings.MusicVolume);
        _view.SoundVolumeSlider.SetValueWithoutNotify(_model.GameSettings.SoundVolume);
        _view.VoiceVolumeSlider.SetValueWithoutNotify(_model.GameSettings.VoiceVolume);
        _view.SubtitlesToogle.isOn = _model.GameSettings.IsSubtitlesOn;
    }

    private void InitButtons()
    {
        _model.SettingsIsSaved.OnValueChanged.AddListener(ChangeSaveSettingsButtonInteractibilyty);

        _view.BrightnessVolumeSlider.onValueChanged.AddListener(_model.ChangeBrightnessVolume);
        _view.ContrastRatioSlider.onValueChanged.AddListener(_model.ChangeContrastRatio);
        _view.EffectVolumeSlider.onValueChanged.AddListener(_model.ChangeEffectVolume);
        _view.MasterVolumeSlider.onValueChanged.AddListener(_model.ChangeMasterVolume);
        _view.MusicVolumeSlider.onValueChanged.AddListener(_model.ChangeMusicVolume);
        _view.SoundVolumeSlider.onValueChanged.AddListener(_model.ChangeMusicVolume);
        _view.VoiceVolumeSlider.onValueChanged.AddListener(_model.ChangeVoiceVolume);
        _view.SubtitlesToogle.onValueChanged.AddListener(_model.ChangeSubtitlesOnOff);

        _view.SaveSettingsButton.onClick.AddListener(_model.SaveSettings);
    }

    private void DeinitButtons()
    {
        _model.SettingsIsSaved.OnValueChanged.RemoveListener(ChangeSaveSettingsButtonInteractibilyty);

        _view.BrightnessVolumeSlider.onValueChanged.RemoveListener(_model.ChangeBrightnessVolume);
        _view.ContrastRatioSlider.onValueChanged.RemoveListener(_model.ChangeContrastRatio);
        _view.EffectVolumeSlider.onValueChanged.RemoveListener(_model.ChangeEffectVolume);
        _view.MasterVolumeSlider.onValueChanged.RemoveListener(_model.ChangeMasterVolume);
        _view.MusicVolumeSlider.onValueChanged.RemoveListener(_model.ChangeMusicVolume);
        _view.SoundVolumeSlider.onValueChanged.RemoveListener(_model.ChangeMusicVolume);
        _view.VoiceVolumeSlider.onValueChanged.RemoveListener(_model.ChangeVoiceVolume);
        _view.SubtitlesToogle.onValueChanged.RemoveListener(_model.ChangeSubtitlesOnOff);

        _view.SaveSettingsButton.onClick.RemoveListener(_model.SaveSettings);
    }

    private void InitActions()
    {
        _model.SettingsIsSaved.OnValueChanged.AddListener(_model.AutoUpdateSettings);
    }

    private void DeInitActions()
    {
        _model.SettingsIsSaved.OnValueChanged.RemoveListener(_model.AutoUpdateSettings);
    }

    private void ChangeSaveSettingsButtonInteractibilyty(bool isInteractable) => _view.SaveSettingsButton.interactable = isInteractable;

    
}

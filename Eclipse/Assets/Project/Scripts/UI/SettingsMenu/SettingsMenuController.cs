public class SettingsMenuController : BaseGameObjectController
{
    public SettingsMenuController(SettingsMenuScriptableObject settingsDefaults, SettingsMenuView view) : base(view)
    {
        Init(settingsDefaults, view);
    }

    protected void Init(IScriptableObject data, IView view)
    {
        base.Init(view);

        _model = new SettingsMenuModel(data as SettingsMenuScriptableObject);

        SetButtonsVolumes();
        InitButtons();
        InitActions();
    }

    public override void Dispose()
    {
        DeinitButtons();
        DeInitActions();

        base.Dispose();
    }


    private void SetButtonsVolumes()
    {
        var view = _view as SettingsMenuView;
        var model = _model as SettingsMenuModel;

        view.BrightnessVolumeSlider.SetValueWithoutNotify(model.GameSettings.BrightnessVolume);
        view.ContrastRatioSlider.SetValueWithoutNotify(model.GameSettings.ContrastRatio);
        view.EffectVolumeSlider.SetValueWithoutNotify(model.GameSettings.EffectVolume);
        view.MasterVolumeSlider.SetValueWithoutNotify(model.GameSettings.MasterVolume);
        view.MusicVolumeSlider.SetValueWithoutNotify(model.GameSettings.MusicVolume);
        view.SoundVolumeSlider.SetValueWithoutNotify(model.GameSettings.SoundVolume);
        view.VoiceVolumeSlider.SetValueWithoutNotify(model.GameSettings.VoiceVolume);
        view.SubtitlesToogle.isOn = model.GameSettings.IsSubtitlesOn;
    }

    private void InitButtons()
    {
        var view = _view as SettingsMenuView;
        var model = _model as SettingsMenuModel;

        model.SettingsIsSaved.OnValueChanged.AddListener(ChangeSaveSettingsButtonInteractibilyty);

        view.BrightnessVolumeSlider.onValueChanged.AddListener(model.ChangeBrightnessVolume);
        view.ContrastRatioSlider.onValueChanged.AddListener(model.ChangeContrastRatio);
        view.EffectVolumeSlider.onValueChanged.AddListener(model.ChangeEffectVolume);
        view.MasterVolumeSlider.onValueChanged.AddListener(model.ChangeMasterVolume);
        view.MusicVolumeSlider.onValueChanged.AddListener(model.ChangeMusicVolume);
        view.SoundVolumeSlider.onValueChanged.AddListener(model.ChangeSoundVolume);
        view.VoiceVolumeSlider.onValueChanged.AddListener(model.ChangeVoiceVolume);
        view.SubtitlesToogle.onValueChanged.AddListener(model.ChangeSubtitlesOnOff);

        view.BackToMainMenuButton.onClick.AddListener(ActivateMainMenu);
        view.KeyBindSettingsButton.onClick.AddListener(ActivateKeyBindSettingsMenu);
        view.BackToMainMenuButton.onClick.AddListener(model.DiscardSettings);
        view.SaveSettingsButton.onClick.AddListener(model.SaveSettings);
    }

    private void DeinitButtons()
    {
        var view = _view as SettingsMenuView;
        var model = _model as SettingsMenuModel;

        model?.SettingsIsSaved.OnValueChanged.RemoveListener(ChangeSaveSettingsButtonInteractibilyty);

        view?.BrightnessVolumeSlider.onValueChanged.RemoveListener(model.ChangeBrightnessVolume);
        view?.ContrastRatioSlider.onValueChanged.RemoveListener(model.ChangeContrastRatio);
        view?.EffectVolumeSlider.onValueChanged.RemoveListener(model.ChangeEffectVolume);
        view?.MasterVolumeSlider.onValueChanged.RemoveListener(model.ChangeMasterVolume);
        view?.MusicVolumeSlider.onValueChanged.RemoveListener(model.ChangeMusicVolume);
        view?.SoundVolumeSlider.onValueChanged.RemoveListener(model.ChangeMusicVolume);
        view?.VoiceVolumeSlider.onValueChanged.RemoveListener(model.ChangeVoiceVolume);
        view?.SubtitlesToogle.onValueChanged.RemoveListener(model.ChangeSubtitlesOnOff);

        view?.BackToMainMenuButton.onClick.RemoveListener(ActivateMainMenu);
        view?.KeyBindSettingsButton.onClick.RemoveListener(ActivateKeyBindSettingsMenu);
        view?.BackToMainMenuButton.onClick.RemoveListener(model.DiscardSettings);
        view?.SaveSettingsButton.onClick.RemoveListener(model.SaveSettings);
    }

    private void InitActions()
    {
        var model = _model as SettingsMenuModel;
        model.SettingsIsSaved.OnValueChanged.AddListener(ChangeSaveSettingsButtonInteractibilyty);
    }

    private void DeInitActions()
    {
        var model = _model as SettingsMenuModel;
        model.SettingsIsSaved.OnValueChanged.RemoveListener(ChangeSaveSettingsButtonInteractibilyty);
    }

    private void ChangeSaveSettingsButtonInteractibilyty(bool settingsIsSaved)
    {
        var view = _view as SettingsMenuView;
        view.SaveSettingsButton.interactable = !settingsIsSaved;
    }

    private void ActivateMainMenu() => GameStateMashine.Instance.ChangeGameState(GameState.MainMenu);
    private void ActivateKeyBindSettingsMenu() => GameStateMashine.Instance.ChangeGameSubState(GameMenuSubState.KeyBindMenu);
}

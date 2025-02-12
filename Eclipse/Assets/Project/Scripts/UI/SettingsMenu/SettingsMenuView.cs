using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : BaseUIView, IView
{
    [SerializeField] private SettingsMenuScriptableObject _settingsDefaults;

    [Header("Buttons")]
    #region Buttons
    [SerializeField] private Button _saveSettingsButton;
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _keyBindSettingsButton;
    #endregion

    [Header("Sliders")]
    #region Sliders
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _effectVolumeSlider;
    [SerializeField] private Slider _voiceVolumeSlider;
    [SerializeField] private Slider _brightnessVolumeSlider;
    [SerializeField] private Slider _contrastRatioSlider;
    [SerializeField] private Toggle _subtitlesToogle;
    #endregion

    private SettingsMenuController _controller;

    #region Properties
    public Slider MasterVolumeSlider { get => _masterVolumeSlider; set => _masterVolumeSlider = value; }
    public Slider SoundVolumeSlider { get => _soundVolumeSlider; set => _soundVolumeSlider = value; }
    public Slider MusicVolumeSlider { get => _musicVolumeSlider; set => _musicVolumeSlider = value; }
    public Slider EffectVolumeSlider { get => _effectVolumeSlider; set => _effectVolumeSlider = value; }
    public Slider VoiceVolumeSlider { get => _voiceVolumeSlider; set => _voiceVolumeSlider = value; }
    public Slider BrightnessVolumeSlider { get => _brightnessVolumeSlider; set => _brightnessVolumeSlider = value; }
    public Slider ContrastRatioSlider { get => _contrastRatioSlider; set => _contrastRatioSlider = value; }
    public Toggle SubtitlesToogle { get => _subtitlesToogle; set => _subtitlesToogle = value; }
    public Button SaveSettingsButton { get => _saveSettingsButton; set => _saveSettingsButton = value; }
    public Button BackToMainMenuButton { get => _backToMainMenuButton; }
    public Button KeyBindSettingsButton { get => _keyBindSettingsButton; }
    #endregion

    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        _controller = new(_settingsDefaults, this);

        CanvasSelector.AddCanvas(GameMenuSubState.SettingsMenu, this);
    }

    private void OnDestroy()
    {
        _controller = null;
    }
}

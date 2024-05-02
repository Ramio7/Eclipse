using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : MonoBehaviour, IView
{
    [SerializeField] private SettingsMenuScriptableObject _settingsDefaults;

    [SerializeField] private Button _saveSettingsButton;
    [SerializeField] private Button _backToMainMenuButton;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _effectVolumeSlider;
    [SerializeField] private Slider _voiceVolumeSlider;
    [SerializeField] private Slider _brightnessVolumeSlider;
    [SerializeField] private Slider _contrastRatioSlider;
    [SerializeField] private Toggle _subtitlesToogle;

    [Header("Canvas")]
    #region Canvas
    [SerializeField] private Canvas _settingsCanvas;
    #endregion

    private SettingsMenuController _controller;

    public Slider MasterVolumeSlider { get => _masterVolumeSlider; set => _masterVolumeSlider = value; }
    public Slider SoundVolumeSlider { get => _soundVolumeSlider; set => _soundVolumeSlider = value; }
    public Slider MusicVolumeSlider { get => _musicVolumeSlider; set => _musicVolumeSlider = value; }
    public Slider EffectVolumeSlider { get => _effectVolumeSlider; set => _effectVolumeSlider = value; }
    public Slider VoiceVolumeSlider { get => _voiceVolumeSlider; set => _voiceVolumeSlider = value; }
    public Slider BrightnessVolumeSlider { get => _brightnessVolumeSlider; set => _brightnessVolumeSlider = value; }
    public Slider ContrastRatioSlider { get => _contrastRatioSlider; set => _contrastRatioSlider = value; }
    public Toggle SubtitlesToogle { get => _subtitlesToogle; set => _subtitlesToogle = value; }
    public Button SaveSettingsButton { get => _saveSettingsButton; set => _saveSettingsButton = value; }
    public Canvas SettingsCanvas { get => _settingsCanvas; }
    public Button BackToMainMenuButton { get => _backToMainMenuButton; }

    public static SettingsMenuView Instance;

    private void OnEnable()
    {
        Instance = this;
        DontDestroyOnLoad(this);

        _controller = new(this, _settingsDefaults);
    }

    private void OnDestroy()
    {
        Instance = null;

        _controller.Dispose();

        _controller = null;
    }
}

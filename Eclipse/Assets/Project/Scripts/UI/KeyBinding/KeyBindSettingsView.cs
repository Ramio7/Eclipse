using UnityEngine;
using UnityEngine.UI;

public class KeyBindSettingsView : MonoBehaviour
{
    [SerializeField] private KeyBindSettings m_Settings;

    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _backWithoutSavingButton;

    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _crouchButton;
    [SerializeField] private Button _slideButton;
    [SerializeField] private Button _firstAbilityButton;
    [SerializeField] private Button _secondAbilityButton;
    [SerializeField] private Button _thirdAbilityButton;
    [SerializeField] private Button _fourthAbilityButton;

    public Button BackToMainMenuButton { get => _backToMainMenuButton; }
    public Button BackWithoutSavingButton { get => _backWithoutSavingButton; }

    public Button JumpButton { get => _jumpButton; }
    public Button CrouchButton { get => _crouchButton; }
    public Button SlideButton { get => _slideButton; }
    public Button FirstAbilityButton { get => _firstAbilityButton; }
    public Button SecondAbilityButton { get => _secondAbilityButton; }
    public Button ThirdAbilityButton { get => _thirdAbilityButton; }
    public Button FourthAbilityButton { get => _fourthAbilityButton; }

    private KeyBindSettingsController _controller;

    public static KeyBindSettingsView Instance;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            _controller = new();
        }
    }

    private void OnDestroy()
    {
        Instance = null;

        _controller.Dispose();
        _controller = null;
    }
}

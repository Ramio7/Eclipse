using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardKeyBindSettingsView : MonoBehaviour, IView
{
    [SerializeField] private KeyboardKeyBindSettingsScriptableObject _keyBindSettingsDefaults;
    [SerializeField] private Canvas _canvas;

    private KeyboardKeyBindSettingsController _controller;

    [Header("Canvas buttons")]
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _backWithoutSavingButton;

    [Header("Bind buttons")]
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _crouchButton;
    [SerializeField] private Button _shiftButton;
    [SerializeField] private Button _slideButton;
    [SerializeField] private Button _firstAbilityButton;
    [SerializeField] private Button _secondAbilityButton;
    [SerializeField] private Button _thirdAbilityButton;
    [SerializeField] private Button _fourthAbilityButton;
    [SerializeField] private Button _useTalkButton;
    [SerializeField] private Button _someAbilityButton;

    public Button BackToMainMenuButton { get => _backToMainMenuButton; }
    public Button BackWithoutSavingButton { get => _backWithoutSavingButton; }

    public Button JumpButton { get => _jumpButton; }
    public Button CrouchButton { get => _crouchButton; }
    public Button ShiftButton { get => _shiftButton; }
    public Button SlideButton { get => _slideButton; }
    public Button FirstAbilityButton { get => _firstAbilityButton; }
    public Button SecondAbilityButton { get => _secondAbilityButton; }
    public Button ThirdAbilityButton { get => _thirdAbilityButton; }
    public Button FourthAbilityButton { get => _fourthAbilityButton; }
    public Button UseTalkButton { get => _useTalkButton; }
    public Button SomeAbilityButton { get => _someAbilityButton; }
    public Canvas Canvas { get => _canvas; }

    public List<Button> AbilitiesButtons;

    public static KeyboardKeyBindSettingsView Instance;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            AbilitiesButtons = new() { JumpButton, CrouchButton, ShiftButton, SlideButton, FirstAbilityButton, SecondAbilityButton, ThirdAbilityButton, FourthAbilityButton, UseTalkButton, SomeAbilityButton };

            _controller = new(_keyBindSettingsDefaults, this);
        }
    }

    private void OnDestroy()
    {
        Instance = null;

        _controller.Dispose();
        _controller = null;
    }
}

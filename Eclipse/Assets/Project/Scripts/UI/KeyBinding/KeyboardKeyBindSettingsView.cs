using UnityEngine;
using UnityEngine.UI;

public class KeyboardKeyBindSettingsView : BaseMonoobjectsPanelView<AbilityBindPanel> //отрефакторить на новый родительский класс
{
    [SerializeField] private KeyboardKeyBindSettingsScriptableObject _keyBindSettingsDefaults;

    private KeyboardKeyBindSettingsController _controller;

    [Header("Switch screen buttons")]
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _backWithoutSavingButton;

    public Button BackToMainMenuButton { get => _backToMainMenuButton; }
    public Button BackWithoutSavingButton { get => _backWithoutSavingButton; }

    public static KeyboardKeyBindSettingsView Instance;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            _controller = new(_keyBindSettingsDefaults, this);

            CanvasSelector.AddCanvas(GameState.KeyBindMenu, this);
        }
    }

    private void OnDestroy()
    {
        Instance = null;

        _controller = null;
    }
}

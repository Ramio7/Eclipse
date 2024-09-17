using UnityEngine;
using UnityEngine.UI;

public class KeyboardKeyBindSettingsView : BaseMonoobjectsPanelView<AbilityBindPanel>
{
    private KeyboardKeyBindSettingsController _controller;

    [Header("Switch screen buttons")]
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _backWithoutSavingButton;

    public Button BackToMainMenuButton { get => _backToMainMenuButton; }
    public Button BackWithoutSavingButton { get => _backWithoutSavingButton; }

    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        _controller = new(this);

        CanvasSelector.AddCanvas(GameState.KeyBindMenu, this);
    }

    private void OnDestroy()
    {
        _controller = null;
    }
}

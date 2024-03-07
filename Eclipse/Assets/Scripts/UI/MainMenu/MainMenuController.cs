using UnityEngine;

public class MainMenuController : BaseController
{
    private new MainMenuModel _model;
    private new MainMenuView _view;

    public MainMenuController(MainMenuView view, MainMenuScriptableObject modelData) : base(view)
    {
        _view = view;
        _model = new MainMenuModel(modelData, _view.MainMenuCanvas);
        Init();
    }

    public override void Init()
    {
        base.Init();

        SubscribeButtons();
    }

    public override void Dispose()
    {
        base.Dispose();

        _model.Dispose();

        _model = null;
        _view = null;
    }

    private void SubscribeButtons()
    {
        _view.ContinueGameButton.onClick.AddListener(GameController.Instance.ContinueGame);

        _view.StartGameButton.onClick.AddListener(GameController.Instance.StartGame);

        _view.SettingsButton.onClick.AddListener(ActivateSettingsMenu);
        _view.BackToMainMenuButton.onClick.AddListener(ActivateMainMenu);
#if UNITY_EDITOR
        _view.ExitGameButton.onClick.AddListener(Debug.Break);
#else
        _view.ExitGameButton.onClick.AddListener(Application.Quit);
#endif
    }

    private void SetStartGameActive() => _model.SwitchActiveButton(_view.StartGameButton, _view.ContinueGameButton);
    private void SetContinueGameButtonActive() => _model.SwitchActiveButton(_view.ContinueGameButton, _view.StartGameButton);

    private void ActivateSettingsMenu() => _model.ChangeCanvas(_view.SettingsCanvas);
    private void ActivateMainMenu() => _model.ChangeCanvas(_view.MainMenuCanvas);
}

using UnityEngine;

public class MainMenuController : BaseController
{
    private new MainMenuModel _model;
    private new MainMenuView _view;

    public MainMenuController(IView view, IScriptableObject modelData) : base(view)
    {
        ControllerList.RegisterController(this);

        var tempModelData = modelData as MainMenuScriptableObject; 
        _view = view as MainMenuView;
        _model = new MainMenuModel(tempModelData, _view.MainMenuCanvas);
        Init();
    }

    public override void Init()
    {
        SubscribeButtons();
    }

    public override void Dispose()
    {
        UnsubscribeButtons();

        _model.Dispose();

        _model = null;
        _view = null;
    }

    private void SubscribeButtons()
    {
        _view.ContinueGameButton.onClick.AddListener(GameController.Instance.ContinueGame);
        _view.ContinueGameButton.onClick.AddListener(ActivateGameMenu);

        _view.StartGameButton.onClick.AddListener(GameController.Instance.StartGame);
        _view.StartGameButton.onClick.AddListener(ActivateGameMenu);

        _view.SettingsButton.onClick.AddListener(ActivateSettingsMenu);

#if UNITY_EDITOR
        _view.ExitGameButton.onClick.AddListener(Debug.Break);
#else
        _view.ExitGameButton.onClick.AddListener(Application.Quit);
#endif
    }

    private void UnsubscribeButtons()
    {
        _view.ContinueGameButton.onClick.RemoveListener(GameController.Instance.ContinueGame);
        _view.ContinueGameButton.onClick.RemoveListener(ActivateGameMenu);

        _view.StartGameButton.onClick.RemoveListener(GameController.Instance.StartGame);
        _view.StartGameButton.onClick.RemoveListener(ActivateGameMenu);

        _view.SettingsButton.onClick.RemoveListener(ActivateSettingsMenu);

#if UNITY_EDITOR
        _view.ExitGameButton.onClick.RemoveListener(Debug.Break);
#else
        _view.ExitGameButton.onClick.RemoveListener(Application.Quit);
#endif
    }

    private void SetStartGameButtonActive() => _model.SwitchActiveButton(_view.StartGameButton, _view.ContinueGameButton);
    private void SetContinueGameButtonActive() => _model.SwitchActiveButton(_view.ContinueGameButton, _view.StartGameButton);

    private void ActivateSettingsMenu() => GameStateMashine.Instance.ChangeGameState(GameState.SettingsMenu);
    private void ActivateGameMenu() => GameStateMashine.Instance.ChangeGameState(GameState.Village); //временно, доработать по завершению системы сохранений
}

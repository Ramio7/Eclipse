using UnityEngine;

public class MainMenuController : BaseGameObjectController
{
    private new MainMenuModel _model;
    private new MainMenuView _view;

    private GameController _gameController;

    public MainMenuController(MainMenuScriptableObject modelData, MainMenuView view) : base(modelData, view)
    {
        Init(modelData, view);
    }

    public override void Init(IScriptableObject modelData, IView view)
    {
        base.Init();

        ControllerList.FindController(out GameController gameController);
        _gameController = gameController;
        _view = view as MainMenuView;
        _model = new MainMenuModel(modelData as MainMenuScriptableObject, _view.MainMenuCanvas);

        SubscribeButtons();
    }

    public override void Dispose()
    {
        UnsubscribeButtons();

        base.Dispose();
        _view = null;
    }

    private void SubscribeButtons()
    {
        _view.ContinueGameButton.onClick.AddListener(_gameController.ContinueGame);
        _view.ContinueGameButton.onClick.AddListener(ActivateGameMenu);

        _view.StartGameButton.onClick.AddListener(_gameController.StartGame);
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
        _view.ContinueGameButton.onClick.RemoveListener(_gameController.ContinueGame);
        _view.ContinueGameButton.onClick.RemoveListener(ActivateGameMenu);

        _view.StartGameButton.onClick.RemoveListener(_gameController.StartGame);
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

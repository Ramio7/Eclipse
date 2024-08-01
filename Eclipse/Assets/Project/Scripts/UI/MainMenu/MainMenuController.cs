using UnityEngine;

public class MainMenuController : BaseGameObjectController
{
    private new MainMenuModel _model;
    private new MainMenuView _view;

    public MainMenuController(MainMenuScriptableObject modelData, MainMenuView view) : base(modelData, view)
    {
        Init(modelData, view);
    }

    public override void Init(IScriptableObject modelData, IView view)
    {
        base.Init();

        _view = view as MainMenuView;
        _model = new MainMenuModel(modelData as MainMenuScriptableObject, _view.Canvas);

        SubscribeButtons();
        SetButtonInGame();
    }

    public override void Dispose()
    {
        UnsubscribeButtons();

        base.Dispose();
        _view = null;
    }

    private void SubscribeButtons()
    {
        _view.ContinueGameButton.onClick.AddListener(ToGame);

        _view.StartGameButton.onClick.AddListener(SceneSelector.SetGameScene);

        _view.StartGameButton.onClick.AddListener(ToGame);

        _view.SettingsButton.onClick.AddListener(ActivateSettingsMenu);

#if UNITY_EDITOR
        _view.ExitGameButton.onClick.AddListener(Debug.Break);
#else
        _view.ExitGameButton.onClick.AddListener(Application.Quit);
#endif
    }

    private void UnsubscribeButtons()
    {
        _view.ContinueGameButton.onClick.RemoveListener(ToGame);

        _view.StartGameButton.onClick.RemoveListener(SceneSelector.SetGameScene);

        _view.StartGameButton.onClick.RemoveListener(ToGame);

        _view.SettingsButton.onClick.RemoveListener(ActivateSettingsMenu);

#if UNITY_EDITOR
        _view.ExitGameButton.onClick.RemoveListener(Debug.Break);
#else
        _view.ExitGameButton.onClick.RemoveListener(Application.Quit);
#endif
    }

    private void SetButtonInGame()
    {
        if (SceneSelector.ActiveScene.buildIndex < (int)GameScens.Game) SetStartGameButtonActive();
        else SetContinueGameButtonActive();
    }
    private void SetStartGameButtonActive() => _model.SwitchActiveButton(_view.StartGameButton, _view.ContinueGameButton);
    private void SetContinueGameButtonActive() => _model.SwitchActiveButton(_view.ContinueGameButton, _view.StartGameButton);

    private void ActivateSettingsMenu() => GameStateMashine.Instance.ChangeGameState(GameState.SettingsMenu);
    private void ToGame() => GameStateMashine.Instance.ChangeGameState(GameState.Game);
}

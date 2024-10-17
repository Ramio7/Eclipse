using UnityEngine;

public class MainMenuController : BaseGameObjectController
{
    public MainMenuController(MainMenuScriptableObject modelData, MainMenuView view) : base(view)
    {
        Init(modelData, view);
    }

    protected void Init(MainMenuScriptableObject modelData, IView view)
    {
        base.Init(view);

        _model = new MainMenuModel(modelData);

        SubscribeButtons();
    }

    public override void Dispose()
    {
        UnsubscribeButtons();

        base.Dispose();
    }

    private void SubscribeButtons()
    {
        var view = _view as MainMenuView;
        var model = _model as MainMenuModel;

        view.StartGameButton.onClick.AddListener(SceneSelector.SetGameScene);

        view.StartGameButton.onClick.AddListener(model.ActivateLoadingScreen);

        view.SettingsButton.onClick.AddListener(model.ActivateSettingsMenu);

        view.ContinueGameButton.onClick.AddListener(model.ReturnToGame);

#if UNITY_EDITOR
        view.ExitGameButton.onClick.AddListener(Debug.Break);
#else
        view.ExitGameButton.onClick.AddListener(Application.Quit);
#endif
    }

    private void UnsubscribeButtons()
    {
        var view = _view as MainMenuView;
        var model = _model as MainMenuModel;

        view?.StartGameButton.onClick.RemoveListener(SceneSelector.SetGameScene);

        view?.StartGameButton.onClick.RemoveListener(model.ActivateLoadingScreen);

        view?.SettingsButton.onClick.RemoveListener(model.ActivateSettingsMenu);

        view?.ContinueGameButton.onClick.RemoveListener(model.ReturnToGame);

#if UNITY_EDITOR
        view?.ExitGameButton.onClick.RemoveListener(Debug.Break);
#else
        _view?.ExitGameButton.onClick.RemoveListener(Application.Quit);
#endif
    }
}

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
        _view = view as MainMenuView;
        _model = new MainMenuModel(modelData as MainMenuScriptableObject);

        SubscribeButtons();
    }

    public override void Dispose()
    {
        UnsubscribeButtons();

        base.Dispose();
    }

    private void SubscribeButtons()
    {
        _view.StartGameButton.onClick.AddListener(SceneSelector.SetGameScene);

        _view.StartGameButton.onClick.AddListener(_model.ActivateLoadingScreen);

        _view.SettingsButton.onClick.AddListener(_model.ActivateSettingsMenu);

        _view.ContinueGameButton.onClick.AddListener(_model.ReturnToGame);

#if UNITY_EDITOR
        _view.ExitGameButton.onClick.AddListener(Debug.Break);
#else
        _view.ExitGameButton.onClick.AddListener(Application.Quit);
#endif
    }

    private void UnsubscribeButtons()
    {
        _view?.StartGameButton.onClick.RemoveListener(SceneSelector.SetGameScene);

        _view?.StartGameButton.onClick.RemoveListener(_model.ActivateLoadingScreen);

        _view?.SettingsButton.onClick.RemoveListener(_model.ActivateSettingsMenu);

        _view?.ContinueGameButton.onClick.RemoveListener(_model.ReturnToGame);

#if UNITY_EDITOR
        _view?.ExitGameButton.onClick.RemoveListener(Debug.Break);
#else
        _view?.ExitGameButton.onClick.RemoveListener(Application.Quit);
#endif
    }
}

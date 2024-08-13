public class KeyboardKeyBindSettingsController : BaseGameObjectController
{
    public KeyboardKeyBindSettingsController(KeyboardKeyBindSettingsScriptableObject defaults, KeyboardKeyBindSettingsView view) : base(defaults, view)
    {
        Init(defaults, view);
    }

    public override void Init(IScriptableObject data, IView view)
    {
        _view = view as KeyboardKeyBindSettingsView;
        _model = new KeyboardKeyBindSettingsModel(data as KeyboardKeyBindSettingsScriptableObject);

        SubscribeButtons();
    }

    public override void Dispose()
    {
        UnsubscribeButtons();

        base.Dispose();
    }

    private void SubscribeButtons()
    {
        var view = _view as KeyboardKeyBindSettingsView;
        var model = _model as KeyboardKeyBindSettingsModel;

        view.BackToMainMenuButton.onClick.AddListener(ActivateSettingsMenu);
        view.BackToMainMenuButton.onClick.AddListener(model.SaveSettings);
        view.BackWithoutSavingButton.onClick.AddListener(ActivateSettingsMenu);
        view.BackWithoutSavingButton.onClick.AddListener(model.DiscardSettings);

        foreach (var abilityPanel in view.Objects)
        {
            abilityPanel.OnAbilityBinded += model.SetKeyBind;
        }
    }

    private void UnsubscribeButtons()
    {
        var view = _view as KeyboardKeyBindSettingsView;
        var model = _model as KeyboardKeyBindSettingsModel;

        view.BackToMainMenuButton.onClick.RemoveListener(ActivateSettingsMenu);
        view.BackWithoutSavingButton.onClick.RemoveListener(ActivateSettingsMenu);

        if (model != null)
        {
            view.BackToMainMenuButton.onClick.RemoveListener(model.SaveSettings);
            view.BackWithoutSavingButton.onClick.RemoveListener(model.DiscardSettings);

            foreach (var abilityPanel in view.Objects)
            {
                abilityPanel.OnAbilityBinded -= model.SetKeyBind;
            }
        }
    }

    private void ActivateSettingsMenu() => GameStateMashine.Instance.ChangeGameState(GameState.SettingsMenu);
}

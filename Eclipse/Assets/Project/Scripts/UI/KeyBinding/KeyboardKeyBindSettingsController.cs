public class KeyboardKeyBindSettingsController : BaseGameObjectController
{
    public KeyboardKeyBindSettingsController(KeyboardKeyBindSettingsView view) : base(view)
    {
        Init();
    }

    private new void Init()
    {
        _model = new KeyboardKeyBindSettingsModel();

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
            model.SetKeyBind(abilityPanel.AbilityKeys, abilityPanel.Ability);
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

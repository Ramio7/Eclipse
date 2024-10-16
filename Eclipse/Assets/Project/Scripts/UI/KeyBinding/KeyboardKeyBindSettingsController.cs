using System.Collections.Generic;

public class KeyboardKeyBindSettingsController : BaseGameObjectController
{
    public KeyboardKeyBindSettingsController(KeyboardKeyBindSettingsView view) : base(view)
    {
        Init();
    }

    private new void Init()
    {
        _model = new KeyboardKeyBindSettingsModel();

        InitLinks();
    }

    public override void Dispose()
    {
        DeinitLinks();

        base.Dispose();
    }

    private void InitLinks()
    {
        var view = _view as KeyboardKeyBindSettingsView;
        var model = _model as KeyboardKeyBindSettingsModel;

        view.BackToMainMenuButton.onClick.AddListener(ActivateSettingsMenu);
        view.BackToMainMenuButton.onClick.AddListener(model.SaveSettings);
        view.BackWithoutSavingButton.onClick.AddListener(ActivateSettingsMenu);
        view.BackWithoutSavingButton.onClick.AddListener(model.DiscardSettings);
        model.settingsIsSaved.OnValueChanged.AddListener(ActivateReturnToMainMenuButton);
        model.settingsIsSaved.OnValueChanged.AddListener(UpdateAbilityPanelsPreferences);

        foreach (var abilityPanel in view.Objects)
        {
            abilityPanel.OnAbilityBinded += model.SetKeyBind;
            model.SetKeyBind(abilityPanel.AbilityKeys, abilityPanel.Ability);
        }
        
        if (!model.LoadSettings()) model.SaveSettings();
    }

    private void DeinitLinks()
    {
        var view = _view as KeyboardKeyBindSettingsView;
        var model = _model as KeyboardKeyBindSettingsModel;

        view.BackToMainMenuButton.onClick.RemoveListener(ActivateSettingsMenu);
        view.BackWithoutSavingButton.onClick.RemoveListener(ActivateSettingsMenu);
        model.settingsIsSaved.OnValueChanged.RemoveListener(ActivateReturnToMainMenuButton);
        model.settingsIsSaved.OnValueChanged.RemoveListener(UpdateAbilityPanelsPreferences);

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

    private void ActivateSettingsMenu() => GameStateMashine.Instance.ChangeGameSubState(GameMenuSubState.SettingsMenu);

    private void ActivateReturnToMainMenuButton(bool isSaved)
    {
        var view = _view as KeyboardKeyBindSettingsView;
        view.BackToMainMenuButton.interactable = !isSaved;
    }

    private void UpdateAbilityPanelsPreferences(bool isSaved)
    {
        if (isSaved)
        {
            var view = _view as KeyboardKeyBindSettingsView;
            var model = _model as KeyboardKeyBindSettingsModel;

            FormTempArrays(view, out AbilityBindPanel[] panelArray, out IAbility[] abilitiesArray);
            UpdatePanelInfo(model, panelArray, abilitiesArray);
        }
    }

    private void FormTempArrays(KeyboardKeyBindSettingsView view, out AbilityBindPanel[] panelArray, out IAbility[] abilitiesArray)
    {
        panelArray = view.Objects.ToArray();
        List<IAbility> abilities = new();
        for (var i = 0; i < panelArray.Length; i++)
        {
            abilities.Add(panelArray[i].Ability);
        }
        abilitiesArray = abilities.ToArray();
    }

    private static void UpdatePanelInfo(KeyboardKeyBindSettingsModel model, AbilityBindPanel[] panelArray, IAbility[] abilitiesArray)
    {
        var keysettings = model.TempSettings;
        if (keysettings.Abilities[0] != null)
        {
            for (int i = 0; i < keysettings.keyCodes.Length; i++)
            {
                var tempAbility = keysettings.GetAbility(i);
                ArrayUtility<IAbility>.FindArrayElementIndex(abilitiesArray, tempAbility, out int index);
                var panel = panelArray.GetValue(index) as IAbilityBindPanel;
                panel.SetAbilityKeys(keysettings.GetAbilityKeys(tempAbility));
            }
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyboardKeyBindSettingsController : BaseController
{
    private new KeyboardKeyBindSettingsModel _model;
    private new KeyboardKeyBindSettingsView _view;

    public KeyboardKeyBindSettingsController(KeyboardKeyBindSettingsView view, KeyboardKeyBindSettingsScriptableObject defaults) : base(view)
    {
        _view = view;
        _model = new(defaults, _view.Canvas);

        Init();
        ResetButtonNames();
    }

    public override void Init()
    {
        SubscribeButtons();
    }

    public override void Dispose()
    {
        UnsubscribeButtons();

        _model.Dispose();

        _view = null;
        _model = null;
    }

    private void SubscribeButtons()
    {
        foreach (var button in _view.AbilitiesButtons)
        {
            button.onClick.AddListener(InvokeClickedButton);
        }

        _view.BackToMainMenuButton.onClick.AddListener(ActivateSettingsMenu);
        _view.BackToMainMenuButton.onClick.AddListener(_model.SaveSettings);
        _view.BackToMainMenuButton.onClick.AddListener(UpdateKeyBindings);
        _view.BackWithoutSavingButton.onClick.AddListener(ActivateSettingsMenu);
        _view.BackWithoutSavingButton.onClick.AddListener(ResetButtonNames);
        _view.BackWithoutSavingButton.onClick.AddListener(_model.DiscardSettings);
    }

    private void UnsubscribeButtons()
    {
        foreach (var button in _view.AbilitiesButtons)
        {
            button.onClick.RemoveListener(InvokeClickedButton);
        }

        _view.BackToMainMenuButton.onClick.RemoveListener(ActivateSettingsMenu);
        _view.BackToMainMenuButton.onClick.RemoveListener(_model.SaveSettings);
        _view.BackToMainMenuButton.onClick.RemoveListener(UpdateKeyBindings);
        _view.BackWithoutSavingButton.onClick.RemoveListener(ActivateSettingsMenu);
        _view.BackWithoutSavingButton.onClick.RemoveListener(ResetButtonNames);
        _view.BackWithoutSavingButton.onClick.RemoveListener(_model.DiscardSettings);
    }

    private void InvokeClickedButton()
    {
        EventSystem.current.currentSelectedGameObject.TryGetComponent<Button>(out var clickedButton);
        if (clickedButton != null) _model.InitKeyBindProcess(clickedButton);
        else throw new System.Exception("No button component on selected object");
    }

    private void ActivateSettingsMenu() => GameStateMashine.Instance.ChangeGameState(GameState.SettingsMenu);

    private void ResetButtonNames()
    {
        for (int i = 0; i < _view.AbilitiesButtons.Count; i++)
        {
            var buttonText = _view.AbilitiesButtons[i].GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
                switch (i)
                {
                    case 0:
                        buttonText.text = _model.KeyBindSettings.JumpKey.ToString();
                        break;
                    case 1:
                        buttonText.text = _model.KeyBindSettings.ShiftKey.ToString();
                        break;
                    case 2:
                        buttonText.text = _model.KeyBindSettings.CrouchKey.ToString();
                        break;
                    case 3:
                        buttonText.text = _model.KeyBindSettings.SlideKey.ToString();
                        break;
                    case 4:
                        buttonText.text = _model.KeyBindSettings.FirstAbilityKey.ToString();
                        break;
                    case 5:
                        buttonText.text = _model.KeyBindSettings.SecondAbilityKey.ToString();
                        break;
                    case 6:
                        buttonText.text = _model.KeyBindSettings.ThirdAbilityKey.ToString();
                        break;
                    case 7:
                        buttonText.text = _model.KeyBindSettings.FourthAbilityKey.ToString();
                        break;
                    case 8:
                        buttonText.text = _model.KeyBindSettings.UseTalkKey.ToString();
                        break;
                    case 9:
                        buttonText.text = _model.KeyBindSettings.SomeAbilityKey.ToString();
                        break;
                    default:
                        Debug.LogWarning("Unsuspected value");
                        break;
                }
        }
    }

    private void UpdateKeyBindings()
    {
        
    }

    public void SetCharacter(ICharacter character) { }
}

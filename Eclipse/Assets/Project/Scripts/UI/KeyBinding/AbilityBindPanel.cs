using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// add this behaviour instantly to parent object of UnityEngine.UI.Button in key settings menu
public class AbilityBindPanel : BaseUIView, IAbilityBindPanel
{
    private Button _abilityButton;
    private string _abilityName;
    private KeyCode _key;
    private IAbility _ability;

    public KeyCode AbilityKey { get => _key; set => _key = value; }
    public IAbility Ability { get => _ability; set => _ability = value; }

    public Action<ICharacter, KeyCode, IAbility> OnAbilityBinded;

    private void Awake()
    {
        _abilityButton = GetComponentInChildren<Button>();
        _abilityName = GetComponentInChildren<TMP_Text>().text;

        _abilityButton.onClick.AddListener(InitKeyBinding);
    }

    private void Start()
    {
        Task.Run(() => AwaitKeyboardKeyBindSettingsModelAsync());
        AbilitiesPool.AddOrUpdateAbility(AbilitiesPool.MainCharacter, _key, _ability);
    }

    private void OnDestroy()
    {
        _abilityButton.onClick.RemoveAllListeners();

        _abilityName = null;
        _abilityButton = null;
    }

    private Task AwaitKeyboardKeyBindSettingsModelAsync()
    {
        ModelList.FindModel(out KeyboardKeyBindSettingsModel keyBindSettingsModel);
        if (keyBindSettingsModel == null)
        {
            ModelList.FindModel(out keyBindSettingsModel);
            return Task.Delay(100);
        }
        else return Task.CompletedTask;
        //else
        //{
        //    if (_ability == null) Task.Delay(100);

        //    OnAbilityBinded?.Invoke(AbilitiesPool.MainCharacter, _key, _ability);
        //    return Task.CompletedTask;
        //}
    }

    private void InitKeyBinding()
    {
        EntryPointView.OnGuiUpdate += AwaitKeyUpAsync;
    }

    private void AwaitKeyUpAsync()
    {
        if (Event.current.type != EventType.KeyUp) return;
        else
        {
            SetAbilityKey(Event.current.keyCode);
            EntryPointView.OnGuiUpdate -= AwaitKeyUpAsync;
        }
    }

    public void SetAbilityKey(KeyCode key)
    {
        _key = key;
        _abilityButton.GetComponentInChildren<TMP_Text>().text = _key.ToString();
        _abilityName = Ability.ToString().Replace("Ability", "");
        OnAbilityBinded?.Invoke(AbilitiesPool.MainCharacter, _key, _ability);
    }
}

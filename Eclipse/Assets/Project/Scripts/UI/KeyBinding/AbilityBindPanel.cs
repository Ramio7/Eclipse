using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// add this behaviour instantly to parent object of UnityEngine.UI.Button
public class AbilityBindPanel : BaseUIView, IAbilityBindPanel
{
    [SerializeField] private AbilityStruct _abilityStruct;
    private Button _abilityButton;
    private TMP_Text _abilityName;

    public Button AbilityButton { get => _abilityButton; private set => _abilityButton = value; }
    public TMP_Text AbilityName { get => _abilityName; set => _abilityName = value; }
    public KeyCode[] AbilityKeys { get => _abilityStruct.Keys; set => _abilityStruct.Keys = value; }
    public IAbility Ability { get => _abilityStruct.Ability; set => _abilityStruct.Ability = (BaseAbility)value; }

    public Action<KeyCode[], IAbility> OnAbilityBinded;

    private event Action<KeyCode> OnFirstKeyDown;
    private event Action<KeyCode> OnSecondKeyUp;
    private KeyCode _tempFirstKey;
    private KeyCode _tempSecondKey;

    private void Awake()
    {
        _abilityButton = GetComponentInChildren<Button>();
        _abilityName = GetComponentInChildren<TMP_Text>();

        _abilityButton.onClick.AddListener(InitKeyBindingAsync);

        OnFirstKeyDown += GetFirstKey;
        OnSecondKeyUp += GetSecondKey;
    }

    private void OnDestroy()
    {
        OnFirstKeyDown -= GetFirstKey;
        OnSecondKeyUp -= GetSecondKey;

        _abilityButton.onClick.RemoveAllListeners();

        _abilityStruct.Dispose();

        _abilityName = null;
        _abilityButton = null;
    }

    private void InitKeyBindingAsync()
    {
        List<KeyCode> abilityKeys = new();
        EntryPointView.OnGuiUpdate += AwaitKeyDown;
    }

    private void AwaitKeyDown()
    {
        if (Event.current == null) return;
        if (Event.current.type != EventType.KeyDown) return;
        else
        {
            EntryPointView.OnGuiUpdate -= AwaitKeyDown;
            OnFirstKeyDown.Invoke(Event.current.keyCode);
        }
    }

    private void GetFirstKey(KeyCode firstKey)
    {
        _tempFirstKey = firstKey;
        EntryPointView.OnGuiUpdate += AwaitKeyUp;
    }

    private void AwaitKeyUp()
    {
        if (Ability.KeysNeeded == 1)
        {
            EntryPointView.OnGuiUpdate -= AwaitKeyUp;
            SetAbilityKeys();
        }
        if (Event.current.type != EventType.KeyUp || Event.current.keyCode == _tempFirstKey) return;
        else
        {
            EntryPointView.OnGuiUpdate -= AwaitKeyUp;
            OnSecondKeyUp.Invoke(Event.current.keyCode);
        }
    }

    private void GetSecondKey(KeyCode secondKey)
    {
        _tempSecondKey = secondKey;
        SetAbilityKeys();
    }

    private void SetAbilityKeys()
    {
        KeyCode[] abilityKeys = new KeyCode[Ability.KeysNeeded];
        var abilityKeysText = AbilityButton.GetComponentInChildren<TMP_Text>();
        switch (abilityKeys.Length)
        {
            case 0:
                throw new Exception("No buttons asinged to ability");
            case 1:
                {
                    abilityKeys[0] = _tempFirstKey;
                    AbilityKeys = abilityKeys;
                    abilityKeysText.text = abilityKeys[0].ToString();
                    break;
                }
            case 2:
                {
                    abilityKeys[0] = _tempFirstKey;
                    abilityKeys[1] = _tempSecondKey;
                    AbilityKeys = abilityKeys;
                    abilityKeysText.text = $"{abilityKeys[0]} + {abilityKeys[1]}";
                    break;
                }
            default:
                throw new ArgumentException("Wrong buttons massive length");
        }
        OnAbilityBinded?.Invoke(AbilityKeys, Ability);
    }
}

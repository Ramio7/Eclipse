using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// add this behaviour instantly to parent object of UnityEngine.UI.Button
[RequireComponent(typeof(IAbility))]
public class AbilityBindPanel : BaseUIView, IAbilityBindPanel
{
    [SerializeField] private KeyCode[] _abilityKeys;
    private Button _abilityButton;
    private TMP_Text _abilityName;
    private IAbility _ability;

    public Button AbilityButton { get => _abilityButton; private set => _abilityButton = value; }
    public TMP_Text AbilityName { get => _abilityName; set => _abilityName = value; }
    public KeyCode[] AbilityKeys { get => _abilityKeys; set => _abilityKeys = value; }
    public IAbility Ability { get => _ability; set => _ability = value; }

    private event Action<KeyCode> OnFirstKeyDown;
    private event Action<KeyCode> OnSecondKeyUp;
    private KeyCode _tempFirstKey;
    private KeyCode _tempSecondKey;

    private void Awake()
    {
        _abilityButton = GetComponentInChildren<Button>();
        _abilityName = GetComponentInChildren<TMP_Text>();
        _ability = GetComponent<IAbility>();

        _abilityButton.onClick.AddListener(InitKeyBindingAsync);

        OnFirstKeyDown += GetFirstKey;
        OnSecondKeyUp += GetSecondKey;
    }

    private void OnDestroy()
    {
        OnFirstKeyDown -= GetFirstKey;
        OnSecondKeyUp -= GetSecondKey;

        _abilityButton.onClick.RemoveAllListeners();

        _abilityKeys = null;
        _abilityName = null;
        _ability = null;
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
                    abilityKeysText.text = abilityKeys[0].ToString();
                    break;
                }
            case 2:
                {
                    abilityKeys[0] = _tempFirstKey;
                    abilityKeys[1] = _tempSecondKey;
                    abilityKeysText.text = $"{abilityKeys[0]} + {abilityKeys[1]}";
                    break;
                }
            default:
                throw new ArgumentException("Wrong buttons massive length");
        }
    }
}

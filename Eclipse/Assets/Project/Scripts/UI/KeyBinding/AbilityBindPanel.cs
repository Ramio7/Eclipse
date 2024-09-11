using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// add this behaviour instantly to parent object of UnityEngine.UI.Button in key settings menu
public class AbilityBindPanel : BaseUIView, IAbilityBindPanel
{
    private Button _abilityButton;
    private TMP_Text _abilityName;
    private KeyCode[] _keys;
    private IAbility _ability;

    public KeyCode[] AbilityKeys { get => _keys; set => _keys = value; }
    public IAbility Ability { get => _ability; set => _ability = value; }

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

    private void Start()
    {
        Task.Run(() => AwaitKeyboardKeyBindSettingsModelAsync());
    }

    private void OnDestroy()
    {
        OnFirstKeyDown -= GetFirstKey;
        OnSecondKeyUp -= GetSecondKey;

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
        else
        {
            if (_ability == null) Task.Delay(100);

            OnAbilityBinded?.Invoke(_keys, _ability);
            return Task.CompletedTask;
        }
    }

    private void InitKeyBindingAsync()
    {
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
        if (AbilityKeys.Length == 1)
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
        KeyCode[] abilityKeys = new KeyCode[AbilityKeys.Length];
        var abilityKeysText = _abilityButton.GetComponentInChildren<TMP_Text>();
        switch (abilityKeys.Length)
        {
            case 0:
                throw new ArgumentException("No buttons asinged to ability");
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
                throw new ArgumentException("Wrong buttons array length");
        }
        OnAbilityBinded?.Invoke(AbilityKeys, Ability);
    }
}

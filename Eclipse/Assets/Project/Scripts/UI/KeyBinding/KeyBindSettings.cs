using System;
using UnityEngine;

public struct KeyBindSettings : IStruct
{
    private IAbility[] _abilities;

    public KeyCode[][] keyCodes;

    public IAbility[] Abilities { get => _abilities; set => _abilities = value; }

    public void Init()
    {
        _abilities = new IAbility[10];
        keyCodes = new KeyCode[10][];
    }

    public void Dispose()
    {
        _abilities = null;
        keyCodes = null;
    }

    public void GetSettings(out IAbility[] i_abilities, out KeyCode[][] i_keyCodes)
    {
        if (_abilities != null) i_abilities = _abilities;
        else i_abilities = new IAbility[10];
        i_keyCodes = keyCodes;
    }

    public KeyCode[] GetAbilityKeys(IAbility ability)
    {
        ArrayUtility<IAbility>.FindArrayElementIndex(_abilities, ability, out int abilityIndex);
        return keyCodes[abilityIndex];
    }

    public IAbility GetAbility(int index) => _abilities[index];

    public void SetFromSettings(KeyBindSettings tempSettings)
    {
        tempSettings.GetSettings(out _abilities, out keyCodes);
    }

    public void SetAbility(IAbility ability, KeyCode[] keys)
    {
        if (ArrayUtility<IAbility>.FindArrayElementIndex(_abilities, ability, out int index))
        {
            switch (keys.Length)
            {
                case 0:
                    throw new ArgumentException($"No key assigned to {ability}");
                case 1:
                    keyCodes[index] = new KeyCode[1];
                    keyCodes[index][0] = keys[0];
                    break;
                case 2:
                    keyCodes[index] = new KeyCode[2];
                    keyCodes[index][0] = keys[0];
                    keyCodes[index][1] = keys[1];
                    break;
                default:
                    throw new ArgumentException($"To much keys assigned to {ability}");
            }
        }
        else
        {
            var freeIndex = ArrayUtility<IAbility>.GetFreeIndex(_abilities);
            _abilities[freeIndex] = ability;
            switch (keys.Length)
            {
                case 0:
                    throw new ArgumentException($"No key assigned to {ability}");
                case 1:
                    keyCodes[freeIndex] = new KeyCode[1];
                    keyCodes[freeIndex][0] = keys[0];
                    break;
                case 2:
                    keyCodes[freeIndex] = new KeyCode[2];
                    keyCodes[freeIndex][0] = keys[0];
                    keyCodes[freeIndex][1] = keys[1];
                    break;
                default:
                    throw new ArgumentException($"To much keys assigned to {ability}");
            }
        }
    }

    public bool IsEqual(KeyBindSettings other)
    {
        if (_abilities == other._abilities && keyCodes == other.keyCodes) return true;
        return false;
    }
}
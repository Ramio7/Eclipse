using System;
using System.Collections.Generic;
using UnityEngine;

public struct KeyBindSettings : IStruct
{
    private Dictionary<IAbility, KeyCode[]> _abilityKyes;

    public IAbility[] Abilities;
    public KeyCode[,] KeyCodes;

    public Dictionary<IAbility, KeyCode[]> AbilityKyes { get => _abilityKyes; private set => _abilityKyes = value; }

    public void Init()
    {
        _abilityKyes = new();

        Abilities = new IAbility[10];
        KeyCodes = new KeyCode[10, 2];
    }

    public void Dispose()
    {
        _abilityKyes.Clear();
        _abilityKyes = null;

        Abilities = null;
        KeyCodes = null;
    }

    public Dictionary<IAbility, KeyCode[]> GetSettings() => _abilityKyes;

    public KeyCode[] GetAbilityKeys(IAbility ability) => _abilityKyes[ability];

    public void SetFromSettings(KeyBindSettings tempSettings) => _abilityKyes = tempSettings.GetSettings();

    public void SetDictionary(Dictionary<IAbility, KeyCode[]> keyValuePairs) => _abilityKyes = keyValuePairs;

    public void SetAbility(IAbility ability, KeyCode[] keys)
    {
        if (_abilityKyes.ContainsKey(ability)) _abilityKyes[ability] = keys;
        else _abilityKyes.Add(ability, keys);

        if (ArrayUtility.FindArrayElement(Abilities, ability, out int index))
        {
            KeyCodes[index, 0] = keys[0];
            KeyCodes[index, 1] = keys[1];
        }
        else
        {
            {
                var freeIndex = ArrayUtility.GetFreeIndex(Abilities);
                Abilities[freeIndex] = ability;
                switch (keys.Length)
                {
                    case 0:
                        throw new ArgumentException($"No key assigned to {ability}");
                    case 1:
                        {
                            KeyCodes[freeIndex, 0] = keys[0];
                            break;
                        }
                    case 2:
                        {
                            KeyCodes[freeIndex, 0] = keys[0];
                            KeyCodes[freeIndex, 1] = keys[1];
                            break;
                        }
                    default: 
                        throw new ArgumentException($"To much keys assigned to {ability}");
                }
            }
        }
    }

    public bool IsEqual(KeyBindSettings other)
    {
        if (_abilityKyes == other.AbilityKyes) return true;
        return false;
    }

    public override string ToString()
    {
        string tempString = string.Empty;
        foreach (var ability in _abilityKyes)
        {
            switch (ability.Value.Length)
            {
                case 0:
                    {
                        throw new ArgumentException($"No key assigned to {ability}");
                    }
                case 1:
                    {
                        tempString += $"{ability.Key}: {ability.Value.GetValue(0)}\n";
                        break;
                    }
                case 2:
                    {
                        var firstKeyName = ability.Value.GetValue(0);
                        var secondKeyName = ability.Value.GetValue(1);
                        var abilityKeysNames = firstKeyName + " + " + secondKeyName;
                        tempString += $"{ability.Key}: {abilityKeysNames}\n";
                        break;
                    }
                default: throw new ArgumentException($"To much keys assigned to {ability}");
            }
        }
        return tempString;
    }

    public void SetFromString(string str)
    {
        string[] strings = str.Split("\n");
        foreach (var tempstring in strings)
        {
            var abilityKeyStrings = tempstring.Split(": ");
            var abilityName = abilityKeyStrings[0];
            var abilityKeys = abilityKeyStrings[1];
        }
    }

}
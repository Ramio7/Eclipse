using System.Collections.Generic;
using UnityEngine;

public struct KeyBindSettings : IStruct
{
    private Dictionary<IAbility, KeyCode[]> AbilityKyes;

    public void Init()
    {
        AbilityKyes = new();
    }

    public void Dispose()
    {
        AbilityKyes.Clear();
        AbilityKyes = null;
    }

    public KeyBindSettings Get() => this;

    public override string ToString()
    {
        string tempString = string.Empty;
        foreach (var ability in AbilityKyes)
        {
            switch (ability.Value.Length)
            {
                case 0:
                    {
                        throw new System.ArgumentException($"No key assigned to {ability}");
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
                default: throw new System.ArgumentException($"To much keys assigned to {ability}");
            }
        }
        return tempString;
    }

    public KeyCode[] GetAbilityKeys(IAbility ability) => AbilityKyes[ability];

    public void SetDictionary(Dictionary<IAbility, KeyCode[]> keyValuePairs) => AbilityKyes = keyValuePairs;

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

    public void SetAbility(IAbility ability, KeyCode[] keys)
    {
        if (AbilityKyes.ContainsKey(ability)) AbilityKyes[ability] = keys;
        else AbilityKyes.Add(ability, keys);
    }
}

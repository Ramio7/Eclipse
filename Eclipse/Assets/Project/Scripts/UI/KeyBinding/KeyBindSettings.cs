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
            var abilityKeysNames = ability.Value.ToString().Split(" ");
            var firstKeyName = abilityKeysNames[0];
            var secondKeyName = abilityKeysNames[1];
            tempString += $"{ability.Key}: {abilityKeysNames}\n";
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

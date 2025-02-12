using System;
using System.Collections.Generic;
using UnityEngine;

public struct KeyBindSettings : IStruct
{
    private Dictionary<IAbility, KeyCode> _abilityKeyPairs;

    public IAbility[] Abilities;
    public KeyCode[] Keys;

    public void Init()
    {
        _abilityKeyPairs = new();
    }

    public void Dispose()
    {
        _abilityKeyPairs.Clear();
        _abilityKeyPairs = null;

        Abilities = null;
        Keys = null;
    }

    public void GetSettings(out IAbility[] i_abilities, out KeyCode[] i_keyCodes)
    {
        if (_abilityKeyPairs.Keys != null)
        {
            int i = 0;
            i_abilities = new IAbility[_abilityKeyPairs.Count];
            foreach (var key in _abilityKeyPairs.Keys)
            {
                i_abilities[i] = key;
                i++;
            }
        }
        else throw new Exception("No abilities found");

        if (_abilityKeyPairs.Values != null) 
        {
            int i = 0;
            i_keyCodes = new KeyCode[_abilityKeyPairs.Count];
            foreach (var value in _abilityKeyPairs.Values)
            {
                i_keyCodes[i] = value;
                i++;
            }
        }
        else throw new Exception("No keys found");
    }

    public KeyCode GetAbilityKey(IAbility ability)
    {
        if (_abilityKeyPairs.ContainsKey(ability)) return _abilityKeyPairs[ability];
        else throw new Exception($"{ability} not found in dictionary");
    }

    public IAbility GetAbilityByArrayIndex(int index) => Abilities[index];

    public void SetFromSettings(KeyBindSettings other)
    {
        other.GetSettings(out Abilities, out Keys);
        UpdateDictionary();
    }

    public void SetAbility(IAbility ability, KeyCode key)
    {
        if (_abilityKeyPairs.ContainsKey(ability)) _abilityKeyPairs[ability] = key;
        else _abilityKeyPairs.Add(ability, key);
    }

    public bool IsEqual(KeyBindSettings other)
    {
        if (Abilities == other.Abilities && Keys == other.Keys) return true;
        return false;
    }

    private readonly void UpdateDictionary()
    {
        _abilityKeyPairs.Clear();

        for (int i = 0; i < Abilities.Length; i++)
        {
            _abilityKeyPairs.Add(Abilities[i], Keys[i]);
        }
    }
}
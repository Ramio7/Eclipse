using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilitiesPool : IDisposable
{
    public static Dictionary<IAbility, KeyCode> MainCharacterAbilitiesDictionary;

    
    public static PlayerAbilitiesPool Instance;

    public PlayerAbilitiesPool() 
    {
        if (Instance == null)
        {
            Instance = this;

            MainCharacterAbilitiesDictionary = new();
        }
    }

    public void Dispose()
    {
        MainCharacterAbilitiesDictionary.Clear();
        MainCharacterAbilitiesDictionary = null;
    }

    public static void AddOrUpdateAbility(KeyCode key, IAbility ability)
    {
        if (MainCharacterAbilitiesDictionary.ContainsKey(ability))
        {
            MainCharacterAbilitiesDictionary[ability] = key;
            return;
        }
        else
        {
            MainCharacterAbilitiesDictionary.Add(ability, key);
        }
    }

    public static IAbility GetMainCharacterAbility<T>()
    {
        Type type = typeof(T);
        if (MainCharacterAbilitiesDictionary.Count == 0) return default;
        foreach (var abilityKeysPair in MainCharacterAbilitiesDictionary)
        {
            if (abilityKeysPair.Key.GetType().Equals(type)) return abilityKeysPair.Key;
        }
        return default;
    }

    public static IAbility GetAbilityByKey(ICharacter character, KeyCode key)
    {
        foreach (var abilityKeyPair in MainCharacterAbilitiesDictionary)
        {
            if (abilityKeyPair.Value == key) return abilityKeyPair.Key;
        }
        return default;
    }

    public static IAbility GetMainCharacterAbilityByKey(KeyCode key, IAbility activeAbility)
    {
        var comboAbility = GetMainCharacterComboAbilityByKey(key, activeAbility);
        if (comboAbility != null) return comboAbility;

        foreach (var abilityKeyPair in MainCharacterAbilitiesDictionary)
        {
            if (abilityKeyPair.Value == key) return abilityKeyPair.Key;
        }
        return default;
    }

    public static void ClearCharacterAbilities() => MainCharacterAbilitiesDictionary.Clear();

    private static IComboAbility GetMainCharacterComboAbilityByKey(KeyCode key, IAbility baseAbility)
    {
        if (baseAbility == null) return default;

        var enumerator = MainCharacterAbilitiesDictionary.GetEnumerator();
        for (var i = 0; MainCharacterAbilitiesDictionary.Count > i; i++)
        {
            if (enumerator.Current.Key is not IComboAbility)
            {
                enumerator.MoveNext();
                continue;
            }

            var comboAbility = (IComboAbility)enumerator.Current.Key;
            if (comboAbility.StartAbility != baseAbility)
            {
                enumerator.MoveNext();
                continue;
            }

            var comboAbilityKey = MainCharacterAbilitiesDictionary[comboAbility];
            if (comboAbilityKey != key)
            {
                enumerator.MoveNext();
                continue;
            }
            else
            {
                return comboAbility;
            }
        }
        return default;
    }
}

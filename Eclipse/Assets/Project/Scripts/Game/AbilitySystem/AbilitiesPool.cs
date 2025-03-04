using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesPool : IDisposable
{
    private static MainCharacterView _mainCharacter;


    public static Dictionary<ICharacter, Dictionary<IAbility, KeyCode>> CharactersAbilitiesDictionary;

    
    public static AbilitiesPool Instance;

    public AbilitiesPool() 
    {
        if (Instance == null)
        {
            Instance = this;

            CharactersAbilitiesDictionary = new();

            _mainCharacter = EntryPointView.MainScreenCharacter;
            CharactersAbilitiesDictionary.Add(_mainCharacter, new());
        }
    }

    public void Dispose()
    {
        CharactersAbilitiesDictionary.Clear();
        CharactersAbilitiesDictionary = null;
    }

    public static void AddOrUpdateAbility(ICharacter character, KeyCode key, IAbility ability)
    {
        if (CharactersAbilitiesDictionary.ContainsKey(character) && CharactersAbilitiesDictionary[character].ContainsKey(ability))
        {
            CharactersAbilitiesDictionary[character][ability] = key;
            return;
        }

        if (CharactersAbilitiesDictionary.ContainsKey(character)) CharactersAbilitiesDictionary[character].Add(ability, key);
        else
        {
            CharactersAbilitiesDictionary.Add(character, new());
            CharactersAbilitiesDictionary[character].Add(ability, key);
        }
    }

    public static IAbility GetMainCharacterAbility<T>()
    {
        Type type = typeof(T);
        if (CharactersAbilitiesDictionary[_mainCharacter].Count == 0) return default;
        foreach (var abilityKeysPair in CharactersAbilitiesDictionary[_mainCharacter])
        {
            if (abilityKeysPair.Key.GetType().Equals(type)) return abilityKeysPair.Key;
        }
        return default;
    }

    public static IAbility GetAbilityByKey(ICharacter character, KeyCode key)
    {
        foreach (var abilityKeyPair in CharactersAbilitiesDictionary[character])
        {
            if (abilityKeyPair.Value == key) return abilityKeyPair.Key;
        }
        return default;
    }

    public static IAbility GetMainCharacterAbilityByKey(KeyCode key, IAbility activeAbility)
    {
        var comboAbility = GetMainCharacterComboAbilityByKey(key, activeAbility);
        if (comboAbility != null) return comboAbility;

        foreach (var abilityKeyPair in CharactersAbilitiesDictionary[_mainCharacter])
        {
            if (abilityKeyPair.Value == key) return abilityKeyPair.Key;
        }
        return default;
    }

    public static void DeleteCharacterFromPool(ICharacter character)
    {
        ClearCharacterAbilities(character);

        CharactersAbilitiesDictionary[character] = null;
    }

    public static void ClearCharacterAbilities(ICharacter character) => CharactersAbilitiesDictionary[character].Clear();

    private static IComboAbility GetMainCharacterComboAbilityByKey(KeyCode key, IAbility baseAbility)
    {
        if (baseAbility == null) return default;

        var enumerator = CharactersAbilitiesDictionary[_mainCharacter].GetEnumerator();
        for (var i = 0; CharactersAbilitiesDictionary[_mainCharacter].Count > i; i++)
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

            var comboAbilityKey = CharactersAbilitiesDictionary[_mainCharacter][comboAbility];
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

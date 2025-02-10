using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesPool : IDisposable
{
    public static Dictionary<ICharacter, Dictionary<IAbility, KeyCode>> CharactersAbilitiesDictionary;

    public static MainCharacterView MainCharacter;

    public static AbilitiesPool Instance;

    public AbilitiesPool() 
    {
        if (Instance == null)
        {
            Instance = this;

            CharactersAbilitiesDictionary = new();

            MainCharacter = EntryPointView.Instance.MainScreenCharacter;
            CharactersAbilitiesDictionary.Add(MainCharacter, new());
        }
    }

    public void Dispose()
    {
        foreach (var characterAbilityList in CharactersAbilitiesDictionary.Values)
        {
            foreach (var abilityKeyPair in characterAbilityList)
            {
                abilityKeyPair.Key.Dispose();
                characterAbilityList.Remove(abilityKeyPair.Key);
            }
        }
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
        if (CharactersAbilitiesDictionary.Count == 0) throw new Exception("Main character not added");
        foreach (var abilityKeysPair in CharactersAbilitiesDictionary[MainCharacter])
        {
            if (abilityKeysPair.Key.GetType().Equals(type)) return abilityKeysPair.Key;
        }
        return default;
    }

    public static IAbility GetAbilityByKey(ICharacter character, KeyCode key)
    {
        List<IAbility> abilitiesToMatch = new();
        foreach (var abilityKeyPair in CharactersAbilitiesDictionary[character])
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
}

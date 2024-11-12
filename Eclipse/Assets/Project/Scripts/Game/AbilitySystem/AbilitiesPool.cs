using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesPool : IDisposable
{
    public static Dictionary<ICharacter, Dictionary<IAbility, KeyCode[]>> CharactersAbilitiesDictionary;

    public static MainCharacterView MainCharacter;

    public static AbilitiesPool Instance;

    public AbilitiesPool() 
    {
        if (Instance == null)
        {
            Instance = this;

            CharactersAbilitiesDictionary = new();

            MainCharacter = UnityEngine.Object.FindFirstObjectByType<MainCharacterView>();
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

    public static void AddOrUpdateAbility(ICharacter character, KeyCode[] keys, IAbility ability)
    {
        if (CharactersAbilitiesDictionary.ContainsKey(character) && CharactersAbilitiesDictionary[character].ContainsKey(ability))
        {
            CharactersAbilitiesDictionary[character][ability] = keys;
            return;
        }

        if (CharactersAbilitiesDictionary.ContainsKey(character)) CharactersAbilitiesDictionary[character].Add(ability, keys);
        else
        {
            CharactersAbilitiesDictionary.Add(character, new());
            CharactersAbilitiesDictionary[character].Add(ability, keys);
        }
    }

    public static IAbility GetMainCharacterAbility<T>()
    {
        Type type = typeof(T);
        foreach (var abilityKeysPair in CharactersAbilitiesDictionary[MainCharacter])
        {
            if (abilityKeysPair.Key.GetType().Equals(type)) return abilityKeysPair.Key;
        }
        return default;
    }

    public static IAbility GetAbilityContainingKeys(ICharacter character, KeyCode previousKey, KeyCode currentKey)
    {
        List<IAbility> abilitiesToMatch = new();
        foreach (var abilityKeyPair in CharactersAbilitiesDictionary[character])
        {
            foreach (var abilityKey in abilityKeyPair.Value)
            {
                if (abilityKey == previousKey) abilitiesToMatch.Add(abilityKeyPair.Key);
            }
        }
        return default;
    }

    public static void DeleteCharacterFromAllocator(ICharacter character)
    {
        ClearCharacterAbilities(character);

        CharactersAbilitiesDictionary[character] = null;
    }

    public static void ClearCharacterAbilities(ICharacter character) => CharactersAbilitiesDictionary[character].Clear();
}

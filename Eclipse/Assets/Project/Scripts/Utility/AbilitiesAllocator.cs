using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesAllocator : IDisposable
{
    public static Dictionary<ICharacter, Dictionary<IAbility, KeyCode[]>> CharactersAbilitiesDictionary;

    public static MainCharacterView MainCharacter;

    public static AbilitiesAllocator Instance;

    public AbilitiesAllocator() 
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

    public static List<IAbility> GetAbilitiesContainingKeys(ICharacter character, KeyCode key)
    {
        List<IAbility> abilities = new();

        foreach (var abilityKeyPair in CharactersAbilitiesDictionary[character])
        {
            foreach (var abilityKey in abilityKeyPair.Value)
            {
                if (abilityKey == key) abilities.Add(abilityKeyPair.Key);
            }
        }
        return abilities;
    }

    public static void DeleteCharacterFromAllocator(ICharacter character)
    {
        ClearCharacterAbilities(character);

        CharactersAbilitiesDictionary[character] = null;
    }

    public static void ClearCharacterAbilities(ICharacter character) => CharactersAbilitiesDictionary[character].Clear();
}

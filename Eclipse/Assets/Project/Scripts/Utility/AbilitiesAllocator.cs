using System;
using System.Collections.Generic;

public class AbilitiesAllocator : IDisposable
{
    public static Dictionary<ICharacter, List<IAbility>> CharactersAbilitiesDictionary;

    public static MainCharacterView MainCharacter;
    public static List<IAbility> MainCharacterAbilities;

    public static AbilitiesAllocator Instance;

    public AbilitiesAllocator() 
    {
        if (Instance == null)
        {
            Instance = this;

            CharactersAbilitiesDictionary = new();

            MainCharacter = UnityEngine.Object.FindFirstObjectByType<MainCharacterView>();
            MainCharacterAbilities = new List<IAbility>();
        }
    }

    public void Dispose()
    {
        CharactersAbilitiesDictionary.Clear();
        CharactersAbilitiesDictionary = null;
    }

    /*public static void AddNewCharacter(ICharacter character)
    {
        if (!CharactersAbilitiesDictionary.ContainsKey(character))
        {
            var abilitiesList = character.Abilities;
            CharactersAbilitiesDictionary.Add(character, abilitiesList);
        }
    }*/

    public static void RemoveCharacter(ICharacter character)
    {
        CharactersAbilitiesDictionary.Remove(character);
    }

    public static void AddNewAbility(ICharacter character, IAbility ability) => CharactersAbilitiesDictionary[character].Add(ability);
}

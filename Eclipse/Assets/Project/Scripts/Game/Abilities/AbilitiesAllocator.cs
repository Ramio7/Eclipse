using System;
using System.Collections.Generic;

public class AbilitiesAllocator : IDisposable
{
    public static Dictionary<ICharacter, List<IAbility>> CharactersAbilitiesDictionary;
    public static AbilitiesAllocator Instance;

    public AbilitiesAllocator() 
    {
        if (Instance == null)
        {
            Instance = this;

            CharactersAbilitiesDictionary = new();
        }
    }

    public void Dispose()
    {
        CharactersAbilitiesDictionary.Clear();
        CharactersAbilitiesDictionary = null;
    }

    public static void AddNewCharacter(ICharacter character)
    {
        if (!CharactersAbilitiesDictionary.ContainsKey(character))
        {
            var abilitiesList = character.Abilities;
            for (int i = 0; i < character.Abilities.Count; i++) character.Abilities[i].Init(character);
            CharactersAbilitiesDictionary.Add(character, abilitiesList);
        }
    }

    public static void RemoveCharacter(ICharacter character)
    {
        CharactersAbilitiesDictionary.Remove(character);
    }
}
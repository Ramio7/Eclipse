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
        foreach (var abilityList in CharactersAbilitiesDictionary.Values)
        {
            foreach(var ability in abilityList) ability.Dispose();
        }
        CharactersAbilitiesDictionary.Clear();
        CharactersAbilitiesDictionary = null;
    }

    public static void AddNewAbility(ICharacter character, IAbility ability)
    {
        if (character.GameObject.TryGetComponent<MainCharacterView>(out var mainCharacter))
        {
            MainCharacterAbilities.Add(ability);
            return;
        }

        if (CharactersAbilitiesDictionary.ContainsKey(character)) CharactersAbilitiesDictionary[character].Add(ability);
        else
        {
            CharactersAbilitiesDictionary.Add(character, new());
            CharactersAbilitiesDictionary[character].Add(ability);
        }
    }
}

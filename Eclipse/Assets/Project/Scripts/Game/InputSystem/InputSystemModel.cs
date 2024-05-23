using System.Collections.Generic;
using UnityEngine;

public class InputSystemModel : BaseModel
{
    private ICharacter _character;
    private Dictionary<KeyCode, IAbility> _keysMethodsPairs = new();

    public Dictionary<KeyCode, IAbility> KeysMethodsPairs { get => _keysMethodsPairs; }

    public InputSystemModel(IScriptableObject modelData, KeyboardKeyBindSettings keyboardKeyBindSettings)
    {
        _character = EntryPointView.Instance.MainScreenCharacter;
        BindKeysAndAbilities(keyboardKeyBindSettings);
    }

    protected override void Init(IScriptableObject modelData)
    {
        
    }

    public override void Dispose()
    {
        _character = null;

        _keysMethodsPairs.Clear();
        _keysMethodsPairs = null;
    }

    private void BindKeysAndAbilities(KeyboardKeyBindSettings keyBindSettings)
    {
        var fields = keyBindSettings.GetType().GetFields();
        var abilitiesArrayCount = AbilitiesAllocator.CharactersAbilitiesDictionary[_character].Count;
        var keyKodesArrayCount = keyBindSettings.Keys.Count;

        for (int i = 0; i < keyKodesArrayCount; i++)
        {
            var keyName = fields[i].Name;
            var abilityName = keyName.Replace("Key", "Ability");
            
            for (int j = 0; j < abilitiesArrayCount; j++)
            {
                var ability = AbilitiesAllocator.CharactersAbilitiesDictionary[_character][j];
                if (!_keysMethodsPairs.ContainsKey(keyBindSettings.Keys[keyName]) && abilityName.Equals(ability.ToString()))
                    _keysMethodsPairs.Add(keyBindSettings.Keys[keyName], AbilitiesAllocator.CharactersAbilitiesDictionary[_character][j]);
                if (j == AbilitiesAllocator.CharactersAbilitiesDictionary[_character].Count) return;
            }
        }
    }

    public void RebindKeysAndAbilities(KeyboardKeyBindSettings keyBindSettings)
    {
        var fields = keyBindSettings.GetType().GetFields();

        for (int i = 0; i < keyBindSettings.Keys.Count; i++)
        {
            var keyName = fields[i].Name;
            var abilityName = keyName.Replace("Key", "Ability");
        }
    }

    public void SwitchCharacter(ICharacter character) => _character = character;
}

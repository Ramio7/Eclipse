using System.Collections.Generic;
using UnityEngine;

public class BaseInputSystemModel : BaseModel
{
    public BaseInputSystemModel() : base()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    /*private void BindKeysAndAbilities(KeyboardKeyBindSettings keyBindSettings)
    {
        var abilities = AbilitiesAllocator.CharactersAbilitiesDictionary[_character];
        var keyKodesArrayCount = keyBindSettings.Keys.Count;

        for (int i = 0; i < abilities.Count; i++)
        {
            var ability = abilities[i];

            for (int j = 0; j < keyBindSettings.Keys.Count; j++)
            {
                var abilityName = ability.GetType().Name;
                var keyName = abilityName.Replace("Ability", "Key");
                //дописать внесение способности в лист
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

    public void SwitchCharacter(ICharacter character) => _character = character;*/
}

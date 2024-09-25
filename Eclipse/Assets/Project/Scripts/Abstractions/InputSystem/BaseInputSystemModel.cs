using System.Collections.Generic;
using UnityEngine;

public class BaseInputSystemModel : BaseModel
{
    public BaseInputSystemModel() : base()
    {
        Init();
    }

    protected new void Init()
    {
    }

    public override void Dispose()
    {
        
    }

    /*private void BindKeysAndAbilities(KeyBindSettings keyBindSettings)
    {
        var abilities = AbilitiesAllocator.CharactersAbilitiesDictionary[_character];
        var keyKodesArrayCount = keyBindSettings._abilityKyes.Count;

        for (int i = 0; i < abilities.Count; i++)
        {
            var ability = abilities[i];

            for (int j = 0; j < keyBindSettings._abilityKyes.Count; j++)
            {
                var abilityName = ability.GetType().Name;
                var keyName = abilityName.Replace("Ability", "Key");
                //дописать внесение способности в лист
            }
        }
    }

    public void RebindKeysAndAbilities(KeyBindSettings keyBindSettings)
    {
        var fields = keyBindSettings.GetType().GetFields();

        for (int i = 0; i < keyBindSettings._abilityKyes.Count; i++)
        {
            var keyName = fields[i].Name;
            var abilityName = keyName.Replace("Key", "Ability");
        }
    }

    public void SwitchCharacter(ICharacter character) => _character = character;*/
}

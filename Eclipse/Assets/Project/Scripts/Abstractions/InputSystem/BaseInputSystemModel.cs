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

    /*private void BindKeysAndAbilities(KeyBindSettings keyBindSettings)
    {
        var abilities = AbilitiesAllocator.CharactersAbilitiesDictionary[_character];
        var keyKodesArrayCount = keyBindSettings.AbilityKyes.Count;

        for (int i = 0; i < abilities.Count; i++)
        {
            var ability = abilities[i];

            for (int j = 0; j < keyBindSettings.AbilityKyes.Count; j++)
            {
                var abilityName = ability.GetType().Name;
                var keyName = abilityName.Replace("Ability", "Key");
                //�������� �������� ����������� � ����
            }
        }
    }

    public void RebindKeysAndAbilities(KeyBindSettings keyBindSettings)
    {
        var fields = keyBindSettings.GetType().GetFields();

        for (int i = 0; i < keyBindSettings.AbilityKyes.Count; i++)
        {
            var keyName = fields[i].Name;
            var abilityName = keyName.Replace("Key", "Ability");
        }
    }

    public void SwitchCharacter(ICharacter character) => _character = character;*/
}

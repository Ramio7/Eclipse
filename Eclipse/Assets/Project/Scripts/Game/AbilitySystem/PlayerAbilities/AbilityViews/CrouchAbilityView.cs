using UnityEngine;

[RequireComponent(typeof(IAbilityBindPanel))]
public class CrouchAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        var ability = new CrouchAbility(AbilitiesAllocator.MainCharacter);
        abilityBindPanel.Ability = ability;
        
    }
}

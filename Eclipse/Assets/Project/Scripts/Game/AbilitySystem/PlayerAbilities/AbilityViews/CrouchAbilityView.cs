using UnityEngine;

[RequireComponent(typeof(IAbilityBindPanel))]
public class CrouchAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new CrouchAbility(AbilitiesAllocator.MainCharacter);
    }
}

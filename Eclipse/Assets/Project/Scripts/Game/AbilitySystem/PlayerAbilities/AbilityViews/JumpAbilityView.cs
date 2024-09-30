using UnityEngine;

[RequireComponent(typeof(IAbilityBindPanel))]
public class JumpAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new JumpAbility(AbilitiesAllocator.MainCharacter, abilityDefaults.KeysWorkType);
    }
}

using UnityEngine;

[RequireComponent(typeof(IAbilityBindPanel))]
public class JumpAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override void InitAsync()
    {
        base.InitAsync();

        var defaults = abilityDefaults as JumpAbilityScriptableObject;

        abilityBindPanel.Ability = new JumpAbility(AbilitiesPool.MainCharacter, defaults.JumpForce);
    }
}

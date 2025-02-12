using UnityEngine;

[RequireComponent(typeof(IAbilityBindPanel))]
public class CrouchAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        abilityBindPanel.Ability = new CrouchAbility(AbilitiesPool.MainCharacter, AbilitiesPool.GetMainCharacterAbility<JumpAbility>());
    }
}

using UnityEngine;

[RequireComponent(typeof(IAbilityBindPanel))]
public class JumpAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        abilityBindPanel.Ability = new JumpAbility(AbilitiesPool.MainCharacter);
    }
}

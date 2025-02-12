public class DoubleJumpAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        abilityBindPanel.Ability = new DoubleJumpAbility(AbilitiesPool.MainCharacter, AbilitiesPool.GetMainCharacterAbility<JumpAbility>());
    }
}

public class DoubleJumpAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new DoubleJumpAbility(AbilitiesPool.MainCharacter, AbilitiesPool.GetMainCharacterAbility<JumpAbility>());
    }
}

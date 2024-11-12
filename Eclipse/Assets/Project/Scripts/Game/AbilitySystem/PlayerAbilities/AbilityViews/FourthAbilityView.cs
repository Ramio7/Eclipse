public class FourthAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new FourthAbility(AbilitiesPool.MainCharacter);
    }
}

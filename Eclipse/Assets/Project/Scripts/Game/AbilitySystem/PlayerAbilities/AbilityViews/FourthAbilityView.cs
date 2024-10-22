public class FourthAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new FourthAbility(AbilitiesAllocator.MainCharacter);
    }
}

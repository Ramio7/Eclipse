public class SecondAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new SecondAbility(AbilitiesAllocator.MainCharacter);
    }
}

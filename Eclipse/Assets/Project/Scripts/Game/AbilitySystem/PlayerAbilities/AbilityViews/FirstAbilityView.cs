public class FirstAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new FirstAbility(AbilitiesAllocator.MainCharacter);
    }
}

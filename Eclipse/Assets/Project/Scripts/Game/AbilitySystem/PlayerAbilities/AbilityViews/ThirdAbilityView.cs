public class ThirdAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new ThirdAbility(AbilitiesAllocator.MainCharacter);
    }
}

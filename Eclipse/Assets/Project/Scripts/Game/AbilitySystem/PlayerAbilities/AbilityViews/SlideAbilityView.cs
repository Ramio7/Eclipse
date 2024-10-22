public class SlideAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new SlideAbility(AbilitiesAllocator.MainCharacter);
    }
}

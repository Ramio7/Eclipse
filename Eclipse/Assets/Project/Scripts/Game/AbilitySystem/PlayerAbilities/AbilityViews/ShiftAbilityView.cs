public class ShiftAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new ShiftAbility(AbilitiesAllocator.MainCharacter);
    }
}

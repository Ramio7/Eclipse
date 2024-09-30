public class MoveAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new MoveAbility(AbilitiesAllocator.MainCharacter, abilityDefaults.KeysWorkType);
    }
}

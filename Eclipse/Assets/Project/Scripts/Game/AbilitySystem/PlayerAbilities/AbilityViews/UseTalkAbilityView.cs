public class UseTalkAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new UseTalkAbility(AbilitiesPool.MainCharacter);
    }
}

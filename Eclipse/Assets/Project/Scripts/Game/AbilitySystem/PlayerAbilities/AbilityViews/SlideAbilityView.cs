public class SlideAbilityView : BaseMainCharacterAbilityView
{
    private void Start()
    {
        abilityBindPanel.Ability = new SlideAbility(AbilitiesPool.MainCharacter);
    }
}

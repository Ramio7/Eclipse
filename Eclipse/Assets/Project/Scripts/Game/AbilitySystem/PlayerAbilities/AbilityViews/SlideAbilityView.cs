public class SlideAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        abilityBindPanel.Ability = new SlideAbility(AbilitiesPool.MainCharacter);
    }
}

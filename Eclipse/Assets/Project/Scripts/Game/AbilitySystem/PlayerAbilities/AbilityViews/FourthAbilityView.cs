public class FourthAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        abilityBindPanel.Ability = new FourthAbility(AbilitiesPool.MainCharacter);
    }
}

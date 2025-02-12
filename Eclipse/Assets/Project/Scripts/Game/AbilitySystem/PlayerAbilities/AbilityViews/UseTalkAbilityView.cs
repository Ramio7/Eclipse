public class UseTalkAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        abilityBindPanel.Ability = new UseTalkAbility(AbilitiesPool.MainCharacter);
    }
}

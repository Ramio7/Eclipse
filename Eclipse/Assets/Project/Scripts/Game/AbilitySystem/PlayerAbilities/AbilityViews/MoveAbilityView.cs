public class MoveAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        abilityBindPanel.Ability = new MoveAbility(AbilitiesPool.MainCharacter);
    }
}

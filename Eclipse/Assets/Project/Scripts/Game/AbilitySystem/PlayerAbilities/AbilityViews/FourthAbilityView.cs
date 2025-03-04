public class FourthAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override void InitAsync()
    {
        base.InitAsync();

        abilityBindPanel.Ability = new FourthAbility(EntryPointView.MainScreenCharacter);
    }
}

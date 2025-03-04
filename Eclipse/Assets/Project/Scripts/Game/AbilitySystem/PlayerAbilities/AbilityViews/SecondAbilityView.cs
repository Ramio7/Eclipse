public class SecondAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override void InitAsync()
    {
        base.InitAsync();

        abilityBindPanel.Ability = new SecondAbility(EntryPointView.MainScreenCharacter);
    }
}

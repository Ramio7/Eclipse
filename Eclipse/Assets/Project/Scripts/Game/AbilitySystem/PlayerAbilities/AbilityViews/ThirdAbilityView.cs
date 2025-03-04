public class ThirdAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override void InitAsync()
    {
        base.InitAsync();

        abilityBindPanel.Ability = new ThirdAbility(EntryPointView.MainScreenCharacter);
    }
}

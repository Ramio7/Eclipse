public class UseTalkAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override void InitAsync()
    {
        base.InitAsync();

        abilityBindPanel.Ability = new UseTalkAbility(EntryPointView.MainScreenCharacter);
    }
}

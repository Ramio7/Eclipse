public class MoveAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override void InitAsync()
    {
        base.InitAsync();

        var defaults = abilityDefaults as MoveAbilityScriptableObject;

        abilityBindPanel.Ability = new MoveAbility(EntryPointView.MainScreenCharacter, defaults.MoveForce);
    }
}

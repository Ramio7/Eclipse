using System.Threading.Tasks;

public class ShiftAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override async void InitAsync()
    {
        base.InitAsync();

        await Task.Run(() => AwaitAbilityInitiation<MoveAbility>());

        abilityBindPanel.Ability = new ShiftAbility(AbilitiesPool.MainCharacter, (MoveAbility)AbilitiesPool.GetMainCharacterAbility<MoveAbility>());
    }
}

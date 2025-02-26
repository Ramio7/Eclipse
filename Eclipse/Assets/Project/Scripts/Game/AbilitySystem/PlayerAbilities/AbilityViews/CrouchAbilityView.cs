using System.Threading.Tasks;

public class CrouchAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override async void InitAsync()
    {
        base.InitAsync();

        await Task.Run(() => AwaitAbilityInitiation<MoveAbility>());

        abilityBindPanel.Ability = new CrouchAbility(AbilitiesPool.MainCharacter, (MoveAbility)AbilitiesPool.GetMainCharacterAbility<MoveAbility>());
    }
}

using System.Threading.Tasks;

public class SlideAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override async void InitAsync()
    {
        base.InitAsync();

        await Task.Run(() => AwaitAbilityInitiation<ShiftAbility>());

        abilityBindPanel.Ability = new SlideAbility(AbilitiesPool.MainCharacter, (ShiftAbility)AbilitiesPool.GetMainCharacterAbility<ShiftAbility>());
    }
}

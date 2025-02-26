using System.Threading.Tasks;

public class DoubleJumpAbilityView : BaseMainCharacterAbilityView
{
    private void Awake()
    {
        InitAsync();
    }

    protected override async void InitAsync()
    {
        base.InitAsync();

        await Task.Run(() => AwaitAbilityInitiation<JumpAbility>());

        var defaults = abilityDefaults as DoubleJumpAbilityScriptableObject;

        abilityBindPanel.Ability = new DoubleJumpAbility(AbilitiesPool.MainCharacter, (JumpAbility)AbilitiesPool.GetMainCharacterAbility<JumpAbility>(), defaults.SecondJumpForce);
    }
}

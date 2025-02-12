using System.Threading.Tasks;
using UnityEngine;

public class UserKeyboardInputModel : BaseInputSystemModel
{
    private IAbility _moveAbility;

    public UserKeyboardInputModel()
    {
        Init();
    }

    protected override async void Init()
    {
        base.Init();

        CurrentKeyOutput.OnValueChanged.AddListener(TakeKeyFromInput);

        await Task.Run(() => AwaitMoveAbilityInitialization());
    }

    public override void Dispose()
    {
        _moveAbility = null;

        base.Dispose();
    }

    private void TakeKeyFromInput(KeyCode key)
    {
        PushAbilityToCash(TakeAbilityFromPull(key));
    }

    private void PushAbilityToCash(IAbility ability)
    {
        if (ability == null) return;
        ability.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
        AbilityCash.AddAbilityToCash(ability);
    }

    private IAbility TakeAbilityFromPull(KeyCode currentKey)
        => AbilitiesPool.GetAbilityByKey(AbilitiesPool.MainCharacter, currentKey);

    private Task AwaitMoveAbilityInitialization()
    {
        while (_moveAbility == null)
        {
            _moveAbility = AbilitiesPool.GetMainCharacterAbility<MoveAbility>();
            Task.Delay(100);
        }
        return Task.CompletedTask;
    }

    public void InvokeMoveAbility()
    {
        if (HorizontalAxis != 0)
        {
            _moveAbility.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
            AbilityCash.AddAbilityToCash(_moveAbility);
        }
    }

    public override void SetKey(KeyCode keyCode)
    {
        lastKeyInput.SetValue(currentKeyOutput.GetValue());
        currentKeyOutput.SetValue(keyCode);
    }

    public override void SetAxis(float horizontalAxisValue, float verticalAxisValue)
    {
        horizontalAxis.SetValue(horizontalAxisValue);
        verticalAxis.SetValue(verticalAxisValue);
    }
}

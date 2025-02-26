using System.Threading.Tasks;
using UnityEngine;

public class UserKeyboardInputModel : BaseInputSystemModel
{
    private IAbility _moveAbility;
    private IAbility _jumpAbility;
    private IAbility _doubleJumpAbility;
    private ReactiveProperty<CharacterEnviromentState> _characterEnviromentState;
    private ReactiveProperty<CharacterAbilitiesState> _abilitiesState;

    public UserKeyboardInputModel()
    {
        InitAsync();
    }

    protected override async void InitAsync()
    {
        base.InitAsync();

        CurrentKeyOutput.OnValueChanged.AddListener(TakeKeyFromInput);

        var character = EntryPointView.Instance.MainScreenCharacter;
        character.BaseCharacterInitiated += GetCharacterStates;
        

        await Task.Run(() => AwaitMoveAbilityInitialization());
        await Task.Run(() => AwaitJumpAbilityInitialization());
        await Task.Run(() => AwaitDoubleJumpAbilityInitialization());
    }

    public override void Dispose()
    {
        _moveAbility = null;
        _jumpAbility = null;
        _characterEnviromentState = null;
        _abilitiesState = null;

        base.Dispose();
    }

    private void GetCharacterStates(BaseCharacterView character)
    {
        _characterEnviromentState = character.EnviromentState;
        _abilitiesState = character.AbilityState;
        character.BaseCharacterInitiated -= GetCharacterStates;
    }

    private void TakeKeyFromInput(KeyCode key)
    {
        var activeAbility = AbilityCash.ActiveAbility;
        PushAbilityToCash(TakeAbilityFromPull(key, activeAbility));
    }

    private void PushAbilityToCash(IAbility ability)
    {
        if (ability == null) return;
        ability.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
        AbilityCash.AddAbilityToCash(ability);
    }

    private IAbility TakeAbilityFromPull(KeyCode currentKey, IAbility activeAbility)
        => AbilitiesPool.GetMainCharacterAbilityByKey(currentKey, activeAbility);

    private Task AwaitMoveAbilityInitialization()
    {
        while (_moveAbility == null)
        {
            _moveAbility = AbilitiesPool.GetMainCharacterAbility<MoveAbility>();
            Task.Delay(100);
        }
        return Task.CompletedTask;
    }

    private Task AwaitJumpAbilityInitialization()
    {
        while (_jumpAbility == null)
        {
            _jumpAbility = AbilitiesPool.GetMainCharacterAbility<JumpAbility>();
            Task.Delay(100);
        }
        return Task.CompletedTask;
    }

    private Task AwaitDoubleJumpAbilityInitialization()
    {
        while (_doubleJumpAbility == null)
        {
            _doubleJumpAbility = AbilitiesPool.GetMainCharacterAbility<DoubleJumpAbility>();
            Task.Delay(100);
        }
        return Task.CompletedTask;
    }

    public void InvokeMoveAbility()
    {
        if (HorizontalAxis != 0 && _characterEnviromentState.GetValue() == CharacterEnviromentState.Grounded)
        {
            if (HorizontalAxis > 0) HorizontalAxis = 1; else HorizontalAxis = -1;
            _moveAbility.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
            AbilityCash.AddAbilityToCash(_moveAbility);
        }
    }

    public void InvokeJumpAbility()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            switch (_characterEnviromentState.GetValue())
            {
                case CharacterEnviromentState.Grounded:
                    AbilityCash.AddAbilityToCash(_jumpAbility);
                    break;
                case CharacterEnviromentState.InAir:
                    if (_abilitiesState.GetValue() == CharacterAbilitiesState.UsedSecondJump) break;
                    AbilityCash.AddAbilityToCash(_doubleJumpAbility);
                    break;
            }
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

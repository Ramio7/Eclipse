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

    protected async void InitAsync()
    {
        base.Init();

        CurrentKeyOutput.OnValueChanged.AddListener(TakeKeyFromInput);

        GameEvents.OnBaseCharacterInitiated += GetCharacterStates;

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
        GameEvents.OnBaseCharacterInitiated -= GetCharacterStates;
    }

    private void TakeKeyFromInput(KeyCode key)
    {
        var activeAbility = PlayerAbilityQueue.InvokedAbility;
        PushAbilityToQueue(TakeAbilityFromPull(key, activeAbility));
    }

    private void PushAbilityToQueue(IAbility ability)
    {
        if (ability == null) return;
        ability.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
        PlayerAbilityQueue.AddAbilityToQueue(ability);
    }

    private IAbility TakeAbilityFromPull(KeyCode currentKey, IAbility activeAbility)
        => PlayerAbilitiesPool.GetMainCharacterAbilityByKey(currentKey, activeAbility);

    private Task AwaitMoveAbilityInitialization()
    {
        while (_moveAbility == null)
        {
            _moveAbility = PlayerAbilitiesPool.GetMainCharacterAbility<MoveAbility>();
            Task.Delay(100);
        }
        return Task.CompletedTask;
    }

    private Task AwaitJumpAbilityInitialization()
    {
        while (_jumpAbility == null)
        {
            _jumpAbility = PlayerAbilitiesPool.GetMainCharacterAbility<JumpAbility>();
            Task.Delay(100);
        }
        return Task.CompletedTask;
    }

    private Task AwaitDoubleJumpAbilityInitialization()
    {
        while (_doubleJumpAbility == null)
        {
            _doubleJumpAbility = PlayerAbilitiesPool.GetMainCharacterAbility<DoubleJumpAbility>();
            Task.Delay(100);
        }
        return Task.CompletedTask;
    }

    public void QueueMoveAbility()
    {
        if (HorizontalAxis != 0 && _characterEnviromentState.GetValue() == CharacterEnviromentState.Grounded)
        {
            if (HorizontalAxis > 0) HorizontalAxis = 1; else HorizontalAxis = -1;
            _moveAbility.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
            PlayerAbilityQueue.AddAbilityToQueue(_moveAbility);
            Input.ResetInputAxes();
        }
    }

    public void QueueJumpAbility()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            switch (_characterEnviromentState.GetValue())
            {
                case CharacterEnviromentState.Grounded:
                    PlayerAbilityQueue.AddAbilityToQueue(_jumpAbility);
                    Input.ResetInputAxes();
                    break;
                case CharacterEnviromentState.InAir:
                    if (_abilitiesState.GetValue() == CharacterAbilitiesState.UsedSecondJump) break;
                    PlayerAbilityQueue.AddAbilityToQueue(_doubleJumpAbility);
                    Input.ResetInputAxes();
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

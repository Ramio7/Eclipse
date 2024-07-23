using System;

public struct CharacterState : IDisposable
{
    public ReactiveProperty<bool> IsIdle;
    public ReactiveProperty<bool> IsInTheAir;
    public ReactiveProperty<bool> IsRunning;
    public ReactiveProperty<bool> IsMoving;
    public ReactiveProperty<bool> IsCrouching;
    public ReactiveProperty<bool> IsSliding;
    public ReactiveProperty<bool> UsingFirstAbility;
    public ReactiveProperty<bool> UsingSecondAbility;
    public ReactiveProperty<bool> UsingThirdAbility;
    public ReactiveProperty<bool> UsingFourthAbility;
    public ReactiveProperty<bool> IsTalking;
    public ReactiveProperty<bool> UsingSomething;

    public CharacterState(bool isIdle, bool isInTheAir, bool isRunning, bool isMoving, bool isCrouching, bool isSliding, 
        bool usingFirstAbility, bool usingSecondAbility, bool usingThirdAbility, bool usingFourthAbility, bool isTalking, 
        bool usingSomething)
    {
        IsIdle = new(true);
        IsInTheAir = new(false);
        IsRunning = new(false);
        IsMoving = new(false);
        IsCrouching = new(false);
        IsSliding = new(false);
        UsingFirstAbility = new(false);
        UsingSecondAbility = new(false);
        UsingThirdAbility = new(false);
        UsingFourthAbility = new(false);
        IsTalking = new(false);
        UsingSomething = new(false);

        IsIdle.SetValue(isIdle);
        IsInTheAir.SetValue(isInTheAir);
        IsRunning.SetValue(isRunning);
        IsMoving.SetValue(isMoving);
        IsCrouching.SetValue(isCrouching);
        IsSliding.SetValue(isSliding);
        UsingFirstAbility.SetValue(usingFirstAbility);
        UsingSecondAbility.SetValue(usingSecondAbility);
        UsingThirdAbility.SetValue(usingThirdAbility);
        UsingFourthAbility.SetValue(usingFourthAbility);
        IsTalking.SetValue(isTalking);
        UsingSomething.SetValue(usingSomething);
    }

    public void Dispose()
    {
        DeinitValues();
    }

    private void DeinitValues()
    {
        IsIdle.Dispose();
        IsMoving.Dispose();
        IsRunning.Dispose();
        IsInTheAir.Dispose();
        IsCrouching.Dispose();
        IsSliding.Dispose();
        UsingFirstAbility.Dispose();
        UsingSecondAbility.Dispose();
        UsingThirdAbility.Dispose();
        UsingFourthAbility.Dispose();
        IsTalking.Dispose();
        UsingSomething?.Dispose();

        IsIdle = null;
        IsMoving = null;
        IsRunning = null;
        IsInTheAir = null;
        IsCrouching = null;
        IsSliding = null;
        UsingFirstAbility = null;
        UsingSecondAbility = null;
        UsingThirdAbility = null;
        UsingFourthAbility = null;
        IsTalking = null;
        UsingSomething = null;
    }

    public void SetIdle(bool isIdle)
    {
        IsIdle.SetValue(isIdle);
        IsMoving.SetValue(false);
        IsRunning.SetValue(false);
        IsCrouching.SetValue(false);
        IsSliding.SetValue(false);
    }

    public void SetInAir(bool isInAir)
    {
        IsInTheAir.SetValue(isInAir);
        IsRunning.SetValue(false);
        IsCrouching.SetValue(false);
        IsSliding.SetValue(false);
    }

    public void SetMoving(bool isMoving)
    {
        IsMoving.SetValue(isMoving);
        IsRunning.SetValue(false);
        IsSliding.SetValue(false);
    }

    public void SetIsRunning(bool isRunning)
    {
        IsRunning.SetValue(isRunning);
        IsCrouching.SetValue(false);
        IsSliding.SetValue(false);
        IsMoving.SetValue(false);
        IsInTheAir.SetValue(false);
    }

    public void SetCrouching(bool isCrouching)
    {
        IsCrouching.SetValue(isCrouching);
        IsRunning.SetValue(false);
        IsSliding.SetValue(false);
        IsInTheAir.SetValue(false);
    }

    public void SetSliding(bool isSliding) => IsSliding.SetValue(isSliding);
    public void SetFirstIsActive(bool isFirstAbilityActive) => UsingFirstAbility.SetValue(isFirstAbilityActive);
    public void SetSecondIsActive(bool isSecondAbilityActive) => UsingSecondAbility.SetValue(isSecondAbilityActive);
    public void SetThirdIsActive(bool isThirdAbilityActive) => UsingThirdAbility.SetValue(isThirdAbilityActive);
    public void SetFourthIsActive(bool isFourthAbilityActive) => UsingFourthAbility.SetValue(isFourthAbilityActive);
    public void SetIsTalking(bool isTalking) => IsTalking.SetValue(isTalking);
    public void SetIsUsing(bool usingSomething) => UsingSomething.SetValue(usingSomething);
}

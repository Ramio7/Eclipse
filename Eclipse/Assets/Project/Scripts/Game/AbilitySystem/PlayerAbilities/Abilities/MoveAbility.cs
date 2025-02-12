using UnityEngine;

public class MoveAbility : BaseAbility
{
    public MoveAbility(ICharacter character) : base(character)
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Method()
    {
        base.Method();
        character.Rigidbody.AddForceX(horizontalAxis, ForceMode2D.Impulse);
        cancellationTokenSource.Cancel();
    }

    public override void SetAbilityInvokeParameters(float horizontalAxisValue, float verticalAxisValue)
    {
        base.SetAbilityInvokeParameters(horizontalAxisValue, verticalAxisValue);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

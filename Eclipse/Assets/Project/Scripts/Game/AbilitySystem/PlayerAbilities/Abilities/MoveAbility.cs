public class MoveAbility : BaseAbility
{
    private float _moveSpeed;

    public MoveAbility(ICharacter character, float moveSpeed) : base(character)
    {
        _moveSpeed = moveSpeed;
    }

    protected override void Method()
    {
        base.Method();
        if (isInvoking) return;
        character.Rigidbody.linearVelocityX = horizontalAxis * _moveSpeed;
    }

    public override void SetAbilityInvokeParameters(float horizontalAxisValue, float verticalAxisValue)
    {
        base.SetAbilityInvokeParameters(horizontalAxisValue, verticalAxisValue);
    }

    public override void Dispose()
    {
        _moveSpeed = 0;

        base.Dispose();
    }
}

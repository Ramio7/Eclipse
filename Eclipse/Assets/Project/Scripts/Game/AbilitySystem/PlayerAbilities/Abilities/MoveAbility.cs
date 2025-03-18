public class MoveAbility : BaseAbility
{
    private float _moveSpeed;

    public MoveAbility(ICharacter character, float moveSpeed) : base(character)
    {
        _moveSpeed = moveSpeed;

        Init();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Method()
    {
        base.Method();
        character.Rigidbody.linearVelocityX = horizontalAxis * _moveSpeed;
        GameEvents.OnAbilityStoped?.Invoke(this);
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

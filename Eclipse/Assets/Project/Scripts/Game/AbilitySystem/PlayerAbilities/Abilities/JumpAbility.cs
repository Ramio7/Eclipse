using UnityEngine;

public class JumpAbility : BaseAbility
{
    private float _jumpForce;

    public JumpAbility(ICharacter character, float jumpForce) : base(character)
    {
        Init();

        _jumpForce = jumpForce;
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Method()
    {
        base.Method();
        //if (isInvoking) return;
        character.Rigidbody.AddForceY(_jumpForce, ForceMode2D.Impulse);
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

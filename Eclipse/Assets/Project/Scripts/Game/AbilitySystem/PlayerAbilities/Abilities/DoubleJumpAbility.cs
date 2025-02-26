using UnityEngine;

public class DoubleJumpAbility : BaseComboAbility
{
    private float _doubleJumpForce;

    public DoubleJumpAbility(ICharacter character, JumpAbility startAbility, float doubleJumpForce) : base(character, startAbility)
    {
        Init();

        _doubleJumpForce = doubleJumpForce;
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Method()
     {
        base.Method();
        if (isInvoking) return;
        character.Rigidbody.AddForceY(_doubleJumpForce, ForceMode2D.Impulse);
        character.AbilityState.SetValue(CharacterAbilitiesState.UsedSecondJump);
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

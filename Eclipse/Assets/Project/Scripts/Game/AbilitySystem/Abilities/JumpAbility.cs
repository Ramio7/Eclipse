using UnityEngine;

public class JumpAbility : BaseAbility
{
    private float _jumpForce = 20;

    public override void InternalMethod()
    {
        _character.Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _character.State.SetInAir(true);
    }
}

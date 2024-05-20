using UnityEngine;

public class JumpAbility : BaseAbility
{
    private float _jumpForce = 20;

    public JumpAbility(ICharacter character) : base(character)
    {
    }

    public override void InternalMethod()
    {
        _character.Rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}

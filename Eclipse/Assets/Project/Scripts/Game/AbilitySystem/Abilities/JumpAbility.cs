using UnityEngine;

public class JumpAbility : BaseAbility
{
    [SerializeField] private float _jumpForce = 20;

    public JumpAbility(ICharacter character) : base(character)
    {
    }

    protected override void InternalMethod()
    {
        _character.Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _character.State.SetInAir(true);
    }
}

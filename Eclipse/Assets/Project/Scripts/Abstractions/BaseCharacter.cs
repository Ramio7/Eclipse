using UnityEngine;

public class BaseCharacter : MonoBehaviour, ICharacter
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public Rigidbody Rigidbody { get => _rigidbody; private set => _rigidbody = value; }
    public Collider Collider { get => _collider; private set => _collider = value; }
}

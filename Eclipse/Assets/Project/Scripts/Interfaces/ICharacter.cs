using UnityEngine;

public interface ICharacter
{
    public Rigidbody Rigidbody { get; }
    public Collider Collider { get; }
}

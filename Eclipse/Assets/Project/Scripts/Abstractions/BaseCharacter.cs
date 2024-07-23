using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, ICharacter
{
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private CharacterState _state;
    protected List<IAbility> _abilities;

    public Rigidbody2D Rigidbody { get => _rigidbody; private set => _rigidbody = value; }
    public Collider2D Collider { get => _collider; private set => _collider = value; }
    public CharacterState State { get => _state; private set => _state = value; }
    public List<IAbility> Abilities { get => _abilities; private set => _abilities = value; }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _state = new();
    }

    private void OnDestroy()
    {
        _state.Dispose();
    }
}

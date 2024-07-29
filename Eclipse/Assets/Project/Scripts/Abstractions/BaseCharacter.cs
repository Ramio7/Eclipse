using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(SpriteLibrary), typeof(SpriteResolver))]
public abstract class BaseCharacter : MonoBehaviour, ICharacter
{
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private CharacterState _state;
    protected List<IAbility> _abilities;
    protected SpriteResolver _spriteResolver;

    public Rigidbody2D Rigidbody { get => _rigidbody; private set => _rigidbody = value; }
    public Collider2D Collider { get => _collider; private set => _collider = value; }
    public CharacterState State { get => _state; private set => _state = value; }
    public List<IAbility> Abilities { get => _abilities; private set => _abilities = value; }
    public SpriteResolver SpriteResolver { get => _spriteResolver; private set => _spriteResolver = value; }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteResolver = GetComponent<SpriteResolver>();
        _state = new();
        _abilities = new();
    }

    private void OnDestroy()
    {
        _state.Dispose();
    }
}

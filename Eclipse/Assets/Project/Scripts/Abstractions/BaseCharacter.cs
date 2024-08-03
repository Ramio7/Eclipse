using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(SpriteLibrary), typeof(SpriteResolver))]
public abstract class BaseCharacter : MonoBehaviour, ICharacter, IView
{
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private CharacterState _state = new();
    protected List<IAbility> _abilities = new();
    protected SpriteResolver _spriteResolver;

    public Rigidbody2D Rigidbody { get => _rigidbody; private set => _rigidbody = value; }
    public Collider2D Collider { get => _collider; private set => _collider = value; }
    public CharacterState State { get => _state; private set => _state = value; }
    public List<IAbility> Abilities { get => _abilities; private set => _abilities = value; }
    public SpriteResolver SpriteResolver { get => _spriteResolver; private set => _spriteResolver = value; }

    public GameObject GameObject { get => gameObject; }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteResolver = GetComponent<SpriteResolver>();
        _state = new(true);
    }

    private void OnDestroy()
    {
        _rigidbody = null;
        _collider = null;
        _spriteResolver = null;
        _state.Dispose();
    }
}

using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SpriteLibrary), typeof(SpriteResolver))]
public abstract class BaseCharacterView : MonoBehaviour, ICharacter, IView
{
    protected Rigidbody2D _rigidbody;
    protected Collider2D _collider;
    protected CharacterState _state = new();
    protected List<IAbility> _abilities = new();

    public Rigidbody2D Rigidbody { get => _rigidbody; private set => _rigidbody = value; }
    public Collider2D Collider { get => _collider; private set => _collider = value; }
    public CharacterState State { get => _state; private set => _state = value; }
    public List<IAbility> Abilities { get => _abilities; private set => _abilities = value; }
    public GameObject GameObject { get => gameObject; }

    private void Start()
    {
        GetComponentsFromMonoBehaviour();
    }

    private void GetComponentsFromMonoBehaviour()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _state = new(true);
        var abilities = GetComponents<IAbilityView>();
        foreach (var ability in abilities) _abilities.Add(ability.Ability);
    }

    private void OnDestroy()
    {
        _rigidbody = null;
        _collider = null;
        _state.Dispose();
        _abilities.Clear();
        _abilities = null;
    }
}

using System;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour, IAbility
{
    [SerializeField] protected Sprite[] animationSprites;
    [SerializeField, Range(1,2)] protected int _keysNeeded;
    protected ICharacter _character;

    public Action Method { get; private set; }
    public Sprite[] AnimationSprites { get => animationSprites; set => animationSprites = value; }
    public int KeysNeeded { get => _keysNeeded; private set => _keysNeeded = value; }

    protected virtual void InternalMethod() { }

    public BaseAbility(ICharacter character)
    {
        Init(_character);
    }

    public void Init(ICharacter character)
    {
        Method = InternalMethod;
        _character = character;
    }

    public void Dispose()
    {
        _character = null;
        Method = null;
    }
}

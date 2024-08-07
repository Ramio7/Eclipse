using System;
using UnityEngine;

public abstract class BaseAbilityView : MonoBehaviour, IAbility
{
    [SerializeField] protected Sprite[] animationSprites;
    protected ICharacter _character;

    public Action Method { get; private set; }
    public Sprite[] AnimationSprites { get => animationSprites; set => animationSprites = value; }

    protected virtual void InternalMethod() { }

    public BaseAbilityView(ICharacter character)
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

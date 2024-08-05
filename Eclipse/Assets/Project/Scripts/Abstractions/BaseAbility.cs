using System;

public abstract class BaseAbility : IAbility
{
    protected ICharacter _character;

    public Action Method { get; private set; }

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

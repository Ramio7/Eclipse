using System;

[Serializable]
public abstract class BaseAbility : IAbility
{
    protected ICharacter _character;

    public Action Method { get; private set; }

    protected abstract void InternalMethod();

    public BaseAbility(ICharacter character)
    {
        Init(character);
    }

    public virtual void Init(ICharacter character)
    {
        Method = InternalMethod;
        _character = character;

        if (character is MainCharacterView) AbilitiesAllocator.MainCharacterAbilities.Add(this);
        else AbilitiesAllocator.AddNewAbility(character, this);
    }

    public virtual void Dispose()
    {
        Method = null;
        _character = null;
    }
}

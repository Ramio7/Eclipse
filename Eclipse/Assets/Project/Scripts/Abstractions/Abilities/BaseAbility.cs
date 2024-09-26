public abstract class BaseAbility : IAbility
{
    protected ICharacter _character;

    public abstract void Invoke();

    public BaseAbility(ICharacter character)
    {
        Init(character);
    }

    public virtual void Init(ICharacter character)
    {
        _character = character;

        AbilitiesAllocator.AddNewAbility(character, this);
    }

    public virtual void Dispose()
    {
        _character = null;
    }
}

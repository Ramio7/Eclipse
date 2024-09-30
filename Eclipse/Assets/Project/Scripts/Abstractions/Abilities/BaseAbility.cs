public abstract class BaseAbility : IAbility
{
    protected ICharacter _character;
    private AbilityKeysWorkType _howKeysIsWorkingTogether = AbilityKeysWorkType.None;


    public ReactiveProperty<bool> IsInvoking;

    public AbilityKeysWorkType HowKeysIsWorkingTogether { get => _howKeysIsWorkingTogether; protected set => _howKeysIsWorkingTogether = value; }

    public BaseAbility(ICharacter character, AbilityKeysWorkType keysWorkType)
    {
        IsInvoking = new(false);
        _howKeysIsWorkingTogether = keysWorkType;
        Init(character);
    }

    public virtual void Init(ICharacter character)
    {
        _character = character;

        AbilitiesAllocator.AddNewAbility(character, this);
    }
    public virtual void Invoke()
    {
        IsInvoking.SetValue(true);
    }

    public virtual void Dispose()
    {
        _character = null;
    }
}

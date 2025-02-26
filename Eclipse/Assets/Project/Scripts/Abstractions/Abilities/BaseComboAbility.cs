public class BaseComboAbility : BaseAbility, IComboAbility
{
    protected IAbility startAbility;

    public IAbility StartAbility { get => startAbility; private set => startAbility = value; }

    public BaseComboAbility(ICharacter character, IAbility startAbility) : base(character)
    {
        this.startAbility = startAbility;

        base.Init();
    }
}

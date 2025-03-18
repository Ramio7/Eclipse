public class FourthAbility : BaseAbility
{
    public FourthAbility(ICharacter character) : base(character)
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Method()
    {
        base.Method();
        //if (isInvoking) return;
    }

    public override void SetAbilityInvokeParameters(float horizontalAxisValue, float verticalAxisValue)
    {
        base.SetAbilityInvokeParameters(horizontalAxisValue, verticalAxisValue);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

public class CrouchAbility : BaseComboAbility
{
    public CrouchAbility(ICharacter character, MoveAbility startAbility) : base(character, startAbility)
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

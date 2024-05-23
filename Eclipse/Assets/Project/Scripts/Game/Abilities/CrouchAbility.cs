public class CrouchAbility : BaseAbility
{
    public override void InternalMethod()
    {
        _character.State.SetCrouching(true);
    }
}

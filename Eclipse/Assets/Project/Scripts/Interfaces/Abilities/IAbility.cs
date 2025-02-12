using System;

public interface IAbility : IDisposable, IMultiTheadingObject
{
    int AbilityId { get; set; }
    void SetAbilityInvokeParameters(float horizontalAxis, float verticalAxis);
    void Invoke();
    void Cancel();
}

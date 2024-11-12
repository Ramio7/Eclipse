using System;

public interface IAbility : IDisposable, IMultiTheadingObject
{
    int AbilityId { get; set; }
    void Init();
    void SetAbilityInvokeParameters(float horizontalAxis, float verticalAxis);
    void Invoke();
    void Cancel();
}

using System;

public interface IAbility : IDisposable, IMultiTheadingObject
{
    int AbilityId { get; set; }
    int AbilityCooldown { get; }
    bool IsInvoking { get; }
    void SetAbilityInvokeParameters(float horizontalAxis, float verticalAxis);
    void Invoke();
    //void ReinitCancellationTokenSource();
}

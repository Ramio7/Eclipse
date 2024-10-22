using System;

public interface IAbility : IDisposable
{
    void Init();
    void SetAbilityInvokeParameters(float horizontalAxis, float verticalAxis);
    void Invoke();
    void Cancel();
}

using System;

public interface IAbility : IDisposable
{
    void Init(ICharacter character);
    void Invoke();
}

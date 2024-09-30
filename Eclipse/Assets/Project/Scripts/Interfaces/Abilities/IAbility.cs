using System;

public interface IAbility : IDisposable
{
    AbilityKeysWorkType HowKeysIsWorkingTogether {  get; }
    void Init(ICharacter character);
    void Invoke();
}

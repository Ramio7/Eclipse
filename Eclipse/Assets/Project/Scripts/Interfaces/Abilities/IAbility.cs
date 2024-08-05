using System;

public interface IAbility : IDisposable
{
    Action Method { get; }

    void Init(ICharacter character);
}

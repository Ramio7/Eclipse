using System;

public interface IAbility
{
    Action Method { get; }

    void InternalMethod();
}

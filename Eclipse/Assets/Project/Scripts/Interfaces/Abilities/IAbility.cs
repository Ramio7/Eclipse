using System;
using UnityEngine;

public interface IAbility : IDisposable
{
    Action Method { get; }
    Sprite[] AnimationSprites { get; }

    void Init(ICharacter character);
}

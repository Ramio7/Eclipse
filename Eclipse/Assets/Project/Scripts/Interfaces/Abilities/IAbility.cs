using System;
using UnityEngine;

public interface IAbility : IDisposable
{
    Action Method { get; }
    Sprite[] AnimationSprites { get; }
    int KeysNeeded { get; }

    void Init(ICharacter character);
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public interface ICharacter
{
    Rigidbody2D Rigidbody { get; }
    Collider2D Collider { get; }
    CharacterState State { get; }
    List<IAbility> Abilities { get; }
    SpriteResolver SpriteResolver { get; }
}

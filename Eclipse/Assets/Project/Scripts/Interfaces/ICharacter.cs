using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    Rigidbody2D Rigidbody { get; }
    Collider2D Collider { get; }
    CharacterState State { get; }
    List<IAbility> Abilities { get; }
}

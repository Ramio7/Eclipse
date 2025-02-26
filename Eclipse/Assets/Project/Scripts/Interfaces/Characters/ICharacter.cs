using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    Rigidbody2D Rigidbody { get; }
    Collider2D Collider { get; }
    ReactiveProperty<CharacterEnviromentState> EnviromentState { get; }
    ReactiveProperty<CharacterAbilitiesState> AbilityState { get; set; }
    List<IAbility> Abilities { get; }
    GameObject GameObject { get; }
}

using System;
using UnityEngine;

public static class GameEvents
{
    public static Action OnUpdate;
    public static Action OnFixedUpdate;
    public static Action OnGuiUpdate;
    public static Action<ICharacter, KeyCode, IAbility> OnAbilityBinded;
}

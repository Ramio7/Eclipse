using System;
using UnityEngine;

public static class GameEvents
{
    public static Action OnUpdate;
    public static Action OnFixedUpdate;
    public static Action OnGuiUpdate;
    public static Action OnLateUpdate;
    public static Action<KeyCode, IAbility> OnPlayerAbilityBinded;
    public static Action OnTimerExpired;
    public static Action OnTimerTick;
    public static Action<BaseCharacterView> OnBaseCharacterInitiated;
    public static Action<IAbility> OnAbilityInitiated;
    public static Action<IAbility> OnAbilityStoped;
}

using UnityEngine;

public interface IAbilityBindPanel : IUIView
{
    KeyCode AbilityKey { get; set; }
    IAbility Ability { get; set; }
    void SetAbilityKey(KeyCode keys);
}

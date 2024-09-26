using UnityEngine;

public interface IAbilityBindPanel : IUIView
{
    KeyCode[] AbilityKeys { get; set; }
    IAbility Ability { get; set; }
    void SetAbilityKeys(KeyCode[] keys);
}

using UnityEngine;

public interface IAbilityStruct : IStruct
{
    public IAbility Ability { get; set; }
    public KeyCode[] Keys { get; set; }
}

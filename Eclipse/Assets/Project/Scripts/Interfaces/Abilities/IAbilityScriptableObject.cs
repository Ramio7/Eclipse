using UnityEngine;

public interface IAbilityScriptableObject : IScriptableObject
{
    int KeysNeeded { get; }
    KeyCode[] KeyCodes { get; }
    int AbilityId { get; set; }
}

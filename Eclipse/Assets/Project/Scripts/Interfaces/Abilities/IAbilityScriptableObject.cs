using UnityEngine;

public interface IAbilityScriptableObject : IScriptableObject
{
    int KeysNeeded { get; }
    KeyCode[] KeyCodes { get; }
    AbilityKeysWorkType KeysWorkType { get; }
    int AbilityId { get; set; }
}

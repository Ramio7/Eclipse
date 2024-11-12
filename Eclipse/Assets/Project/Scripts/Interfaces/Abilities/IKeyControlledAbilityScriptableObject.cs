using UnityEngine;

public interface IKeyControlledAbilityScriptableObject : IScriptableObject
{
    int KeysNeeded { get; }
    KeyCode[] KeyCodes { get; }
    int AbilityId { get; set; }
}

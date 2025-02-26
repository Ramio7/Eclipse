using UnityEngine;

public interface IKeyControlledAbilityScriptableObject : IScriptableObject
{
    KeyCode KeyCode { get; }
    int AbilityId { get; set; }
    int AbilityCooldown { get; }
}

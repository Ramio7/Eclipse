using UnityEngine;

public interface IKeyControlledAbility
{
    int KeysNeeded { get; }
    KeyCode[] KeyCodes { get; }
}

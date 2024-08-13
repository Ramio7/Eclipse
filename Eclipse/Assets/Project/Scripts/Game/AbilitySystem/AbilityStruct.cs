using System;
using UnityEngine;

[Serializable]
public struct AbilityStruct: IStruct
{
    [SerializeField] private BaseAbility _ability;
    [SerializeField] private KeyCode[] _keys;

    public BaseAbility Ability { get => _ability; set => _ability = value; }
    public KeyCode[] Keys { get => _keys; set => _keys = value; }

    public AbilityStruct(BaseAbility ability, KeyCode[] keys)
    {
        _ability = ability;
        _keys = keys;
    }

    public void Dispose()
    {
        _ability.Dispose();

        _ability = null;
        _keys = null;
    }
}

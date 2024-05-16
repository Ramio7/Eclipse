using System;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemModel : BaseModel
{
    private Dictionary<KeyCode, IAbility> _KeysMethodsPairs = new();

    public Dictionary<KeyCode, IAbility> KeysMethodsPairs { get => _KeysMethodsPairs; }

    public InputSystemModel(IScriptableObject modelData, KeyboardKeyBindSettings keyboardKeyBindSettings) //сначала сделать систему способностей
    {

    }

    protected override void Init(IScriptableObject modelData)
    {
        
    }

    public override void Dispose()
    {
        
    }

    private void BindKeysAndMethods(KeyboardKeyBindSettings keyBindSettings)
    {
        //_KeysMethodsPairs.Add(keyBindSettings.JumpKey, JumpMethod);
    }
}

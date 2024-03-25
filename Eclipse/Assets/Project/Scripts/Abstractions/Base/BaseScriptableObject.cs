using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(BaseScriptableObject), fileName = nameof(BaseScriptableObject), order = 0)]
public class BaseScriptableObject : ScriptableObject, IScriptableObject
{
    public List<FieldInfo> Fields { get; private set; } = new();

    public void FillTheFields()
    {
        var fields = GetType().GetFields();
        foreach (var field in fields) Fields.Add(field);
    }
}

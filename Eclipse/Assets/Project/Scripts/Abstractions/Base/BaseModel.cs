using System.Collections.Generic;
using UnityEngine;

public class BaseModel : IModel
{
    protected Dictionary<string, bool> _boolValues = new();
    protected Dictionary<string, int> _intValues = new();
    protected Dictionary<string, float> _floatValues = new();
    protected Dictionary<string, string> _stringValues = new();
    protected Dictionary<string, GameObject> _prefabs = new();

    public BaseModel()
    {
    }

    protected virtual void Init(IScriptableObject modelData) 
    {
        var fields = modelData.Fields;
        
        for (int i = 0; i < fields.Count; i++)
        {
            var fieldType = fields[i].FieldType;
            if (fieldType == typeof(bool)) _boolValues.Add(fields[i].Name, (bool)fields[i].GetValue(fields[i]));
            if (fieldType == typeof(int)) _intValues.Add(fields[i].Name, (int)fields[i].GetValue(fields[i]));
            if (fieldType == typeof(float)) _floatValues.Add(fields[i].Name, (float)fields[i].GetValue(fields[i]));
            if (fieldType == typeof(string)) _stringValues.Add(fields[i].Name, (string)fields[i].GetValue(fields[i]));
            if (fieldType == typeof(GameObject)) _prefabs.Add(fields[i].Name, (GameObject)fields[i].GetValue(fields[i]));
        }
    }

    public virtual void Dispose()
    {
        ClearDictionaries();
        ClearMemory();
    }

    private void ClearDictionaries()
    {
        _boolValues.Clear();
        _intValues.Clear();
        _floatValues.Clear();
        _prefabs.Clear();
        _stringValues.Clear();
    }

    private void ClearMemory()
    {
        _boolValues = null;
        _prefabs = null;
        _intValues = null;
        _floatValues = null;
        _stringValues = null;
    }
}

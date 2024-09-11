using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(BaseAbilityScriptableObject), fileName = nameof(BaseAbilityScriptableObject))]
public abstract class BaseAbilityScriptableObject : ScriptableObject, IAbilityScriptableObject
{
    [SerializeField] protected KeyCode[] keys;

    public int KeysNeeded { get => keys.Length; }
    public KeyCode[] KeyCodes {  get => keys; set => keys = value; }
    public List<FieldInfo> Fields { get; }
}

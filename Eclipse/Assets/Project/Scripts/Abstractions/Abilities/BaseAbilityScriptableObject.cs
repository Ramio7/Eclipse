using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class BaseAbilityScriptableObject : ScriptableObject, IAbilityScriptableObject
{
    [SerializeField] protected int abilityId;
    [SerializeField] protected Sprite[] idleAnimation;
    [SerializeField] protected Sprite[] leftAnimation;
    [SerializeField] protected Sprite[] rightAnimation;
    [SerializeField] protected KeyCode[] keys;
    
    [SerializeField] protected AbilityKeysWorkType keysWorkType;

    public int KeysNeeded { get => keys.Length; }
    public KeyCode[] KeyCodes {  get => keys; set => keys = value; }
    public List<FieldInfo> Fields { get; }
    public Sprite[] IdleAnimation { get => idleAnimation; set => idleAnimation = value; }
    public Sprite[] LeftAnimation { get => leftAnimation; set => leftAnimation = value; }
    public Sprite[] RightAnimation { get => rightAnimation; set => rightAnimation = value; }
    public int AbilityId { get => abilityId; set => abilityId = value; }
    public AbilityKeysWorkType KeysWorkType { get => keysWorkType; protected set => keysWorkType = value; }
}

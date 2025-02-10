using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class BaseAbilityScriptableObject : ScriptableObject, IKeyControlledAbilityScriptableObject
{
    [SerializeField] protected int abilityId;
    [SerializeField] protected Sprite[] idleAnimation;
    [SerializeField] protected Sprite[] leftAnimation;
    [SerializeField] protected Sprite[] rightAnimation;
    [SerializeField] protected KeyCode key;

    public KeyCode KeyCode {  get => key; set => key = value; }
    public List<FieldInfo> Fields { get; }
    public Sprite[] IdleAnimation { get => idleAnimation; set => idleAnimation = value; }
    public Sprite[] LeftAnimation { get => leftAnimation; set => leftAnimation = value; }
    public Sprite[] RightAnimation { get => rightAnimation; set => rightAnimation = value; }
    public int AbilityId { get => abilityId; set => abilityId = value; }
}

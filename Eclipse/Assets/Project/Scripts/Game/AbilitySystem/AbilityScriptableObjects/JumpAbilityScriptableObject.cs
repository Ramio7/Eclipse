using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Abilities/" + nameof(JumpAbilityScriptableObject), fileName = nameof(JumpAbilityScriptableObject))]
public class JumpAbilityScriptableObject : BaseAbilityScriptableObject
{
    [SerializeField] private Sprite[] _jumpIdleAnimation;
    [SerializeField] private Sprite[] _jumpLeftAnimation;
    [SerializeField] private Sprite[] _jumpRightAnimation;
}

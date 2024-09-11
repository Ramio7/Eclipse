using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Abilities/" + nameof(CrouchAbilityScriptableObject), fileName = nameof(CrouchAbilityScriptableObject))]
public class CrouchAbilityScriptableObject : BaseAbilityScriptableObject
{
    [SerializeField] private Sprite[] _crouchIdleAnimation;
    [SerializeField] private Sprite[] _crouchLeftAnimation;
    [SerializeField] private Sprite[] _crouchRightAnimation;
}

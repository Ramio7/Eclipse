using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Abilities/" + nameof(JumpAbilityScriptableObject), fileName = nameof(JumpAbilityScriptableObject))]
public class JumpAbilityScriptableObject : BaseAbilityScriptableObject
{
    [SerializeField] private float _jumpForce = 10;

    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
}

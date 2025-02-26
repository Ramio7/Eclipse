using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Abilities/" + nameof(DoubleJumpAbilityScriptableObject), fileName = nameof(DoubleJumpAbilityScriptableObject))]
public class DoubleJumpAbilityScriptableObject : BaseAbilityScriptableObject
{
    [SerializeField] private float _secondJumpForce = 15;

    public float SecondJumpForce { get => _secondJumpForce; set => _secondJumpForce = value; }
}

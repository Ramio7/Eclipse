using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Abilities/" + nameof(MoveAbilityScriptableObject), fileName = nameof(MoveAbilityScriptableObject))]
public class MoveAbilityScriptableObject : BaseAbilityScriptableObject
{
    [SerializeField] private float _moveForce = 3;

    public float MoveForce { get => _moveForce; set => _moveForce = value; }
}

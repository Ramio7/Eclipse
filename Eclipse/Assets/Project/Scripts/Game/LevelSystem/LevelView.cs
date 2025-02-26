using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Transform _startingPoint;

    public Transform StartingPoint { get => _startingPoint; set => _startingPoint = value; }
}

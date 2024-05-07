using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(GameScriptableObject), fileName = nameof(GameScriptableObject))]
public class GameScriptableObject : BaseScriptableObject
{
    [SerializeField] private GameObject _girlPrefab;
    [SerializeField] private GameOverlayView _overlayView;

    public GameObject GirlPrefab { get => _girlPrefab; }
    public GameOverlayView OverlayView { get => _overlayView; }
}

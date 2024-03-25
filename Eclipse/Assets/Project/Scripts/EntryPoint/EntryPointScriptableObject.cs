using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(EntryPointScriptableObject), fileName = nameof(EntryPointScriptableObject))]
public class EntryPointScriptableObject : BaseScriptableObject
{
    [SerializeField] private GameObject _mainMenuPrefab;
    [SerializeField] private GameObject _gamePrefab;

    public GameObject MainMenuPrefab { get => _mainMenuPrefab; }
    public GameObject GamePrefab { get => _gamePrefab; }
}

using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(EntryPointScriptableObject), fileName = nameof(EntryPointScriptableObject))]
public class EntryPointScriptableObject : BaseScriptableObject
{
    [SerializeField] private GameObject _mainMenuPrefab;
    [SerializeField] private GameObject _settingsMenuPrefab;
    [SerializeField] private GameObject _gamePrefab;
    [SerializeField] private GameObject _keyBindSettingsMenuPrefab;

    public GameObject MainMenuPrefab { get => _mainMenuPrefab; }
    public GameObject SettingsMenuPrefab { get => _settingsMenuPrefab; }
    public GameObject GamePrefab { get => _gamePrefab; }
    public GameObject KeyBindSettingsMenuPrefab { get => _keyBindSettingsMenuPrefab; }
}

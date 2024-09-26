using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(EntryPointScriptableObject), fileName = nameof(EntryPointScriptableObject))]
public class EntryPointScriptableObject : BaseScriptableObject
{
    [SerializeField] private MainMenuView _mainMenuPrefab;
    [SerializeField] private SettingsMenuView _settingsMenuPrefab;
    [SerializeField] private KeyboardKeyBindSettingsView _keyBindSettingsMenuPrefab;
    [SerializeField] private LoadingScreenView _loadingScreenPrefab;

    public MainMenuView MainMenuPrefab { get => _mainMenuPrefab; }
    public SettingsMenuView SettingsMenuPrefab { get => _settingsMenuPrefab; }
    public KeyboardKeyBindSettingsView KeyBindSettingsMenuPrefab { get => _keyBindSettingsMenuPrefab; }
    public LoadingScreenView LoadingScreenPrefab { get => _loadingScreenPrefab; }
}

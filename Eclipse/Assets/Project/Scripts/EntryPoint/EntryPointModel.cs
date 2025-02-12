public class EntryPointModel : BaseScriptableObjectOrientedModel
{
    public MainMenuView MainMenuView { get; private set; }
    public SettingsMenuView SettingsMenuView { get; private set; }
    public KeyboardKeyBindSettingsView KeyBindSettingsMenuView { get; private set; }
    public LoadingScreenView LoadingScreenView { get; private set; }

    public EntryPointModel(IScriptableObject modelData) : base(modelData)
    {
        Init(modelData);
    }

    public override void Init(IScriptableObject modelData)
    {
        base.Init(modelData);

        var tempData = modelData as EntryPointScriptableObject;
        MainMenuView = tempData.MainMenuPrefab;
        SettingsMenuView = tempData.SettingsMenuPrefab;
        KeyBindSettingsMenuView = tempData.KeyBindSettingsMenuPrefab;
        LoadingScreenView = tempData.LoadingScreenPrefab;
    }

    public override void Dispose()
    {
        base.Dispose();
        MainMenuView = null;
        SettingsMenuView = null;
        KeyBindSettingsMenuView = null;
        LoadingScreenView = null;
    }
}

public class EntryPointModel : BaseModel
{
    public MainMenuView MainMenuView { get; private set; }
    public SettingsMenuView SettingsMenuView { get; private set; }
    public KeyboardKeyBindSettingsView KeyBindSettingsMenuView { get; private set; }

    public EntryPointModel(IScriptableObject modelData) : base(modelData)
    {
        Init(modelData);
    }

    protected override void Init(IScriptableObject modelData)
    {
        base.Init(modelData);
        var tempData = modelData as EntryPointScriptableObject;
        MainMenuView = tempData.MainMenuPrefab;
        SettingsMenuView = tempData.SettingsMenuPrefab;
        KeyBindSettingsMenuView = tempData.KeyBindSettingsMenuPrefab;
    }

    public override void Dispose()
    {
        MainMenuView = null;
        SettingsMenuView = null;
        KeyBindSettingsMenuView = null;
    }
}

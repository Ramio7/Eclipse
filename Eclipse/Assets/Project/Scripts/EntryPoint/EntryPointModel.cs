using UnityEngine;

public class EntryPointModel : BaseModel
{
    public GameObject MainMenuView { get; private set; }
    public GameObject SettingsMenuView { get; private set; }
    public GameObject GameView { get; private set; }
    public GameObject KeyBindSettingsMenuView { get; private set; }

    public EntryPointModel(IScriptableObject modelData) : base()
    {
        ModelList.RegisterModel(this);

        Init(modelData);
    }

    protected override void Init(IScriptableObject modelData)
    {
        var tempData = modelData as EntryPointScriptableObject;
        MainMenuView = tempData.MainMenuPrefab;
        SettingsMenuView = tempData.SettingsMenuPrefab;
        GameView = tempData.GamePrefab;
        KeyBindSettingsMenuView = tempData.KeyBindSettingsMenuPrefab;
    }

    public override void Dispose()
    {
        MainMenuView = null;
        SettingsMenuView = null;
        GameView = null;
        KeyBindSettingsMenuView = null;
    }
}

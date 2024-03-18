using UnityEngine;

public class EntryPointModel : BaseModel
{
    public GameObject MainMenuView { get; private set; }
    public GameObject GameView { get; private set; }

    public EntryPointModel(EntryPointScriptableObject modelData) : base()
    {
        Init(modelData);
    }

    protected override void Init(IScriptableObject modelData)
    {
        var tempData = modelData as EntryPointScriptableObject;
        MainMenuView = tempData.MainMenuPrefab;
        GameView = tempData.GamePrefab;
    }

    public override void Dispose()
    {
        MainMenuView = null;
        GameView = null;
    }
}

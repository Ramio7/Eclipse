public class EntryPointController : BaseGameObjectController
{
    private new EntryPointModel _model;

    public EntryPointController(EntryPointScriptableObject modelData, EntryPointView view) : base(modelData, view)
    {
        Init(modelData, view);
    }

    public override void Init(IScriptableObject modelData, IView view)
    {
        _model = new EntryPointModel(modelData as EntryPointScriptableObject);
        _view = view as EntryPointView;

        base.Init();
        InstantiateGame();
        InstantiateMainMenu();
        InstantiateSettingsMenu();
        InstantiateKeyBindSettingsMenu();
        InitInputSystem();
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    private void InstantiateGame() => InstantiateChildObject(_model.GameView);
    private void InstantiateMainMenu() => InstantiateChildObject(_model.MainMenuView);
    private void InstantiateSettingsMenu() => InstantiateChildObject(_model.SettingsMenuView);
    private void InstantiateKeyBindSettingsMenu() => InstantiateChildObject(_model.KeyBindSettingsMenuView);
    private void InitInputSystem()
    {
        ModelList.FindModel(out KeyboardKeyBindSettingsModel model);
        new InputSystemController(model.KeyBindSettings);
    }
}

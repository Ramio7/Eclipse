public class EntryPointController : BaseController
{
    private new EntryPointModel _model;

    public EntryPointController(IView view, IScriptableObject modelData) : base(view)
    {
        ControllerList.RegisterController(this);

        var tempModelData = modelData as EntryPointScriptableObject;
        _model = new EntryPointModel(tempModelData);

        Init();
    }

    public override void Init()
    {
        base.Init();
        InstantiateGame();
        InstantiateMainMenu();
        InstantiateSettingsMenu();
        InstantiateKeyBindSettingsMenu();
        InitInputSystem();
    }

    public override void Dispose()
    {
        _model.Dispose();

        _model = null;
    }

    private void InstantiateGame() => InstantiateChildObject(_model.GameView);
    private void InstantiateMainMenu() => InstantiateChildObject(_model.MainMenuView);
    private void InstantiateSettingsMenu() => InstantiateChildObject(_model.SettingsMenuView);
    private void InstantiateKeyBindSettingsMenu() => InstantiateChildObject(_model.KeyBindSettingsMenuView);
    private void InitInputSystem()
    {
        ModelList.FindModel(out KeyboardKeyBindSettingsModel model);
        var inputSystemController = new InputSystemController(null, model.KeyBindSettings);
    }
}

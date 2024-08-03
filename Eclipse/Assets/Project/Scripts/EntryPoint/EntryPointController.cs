public class EntryPointController : BaseGameObjectController
{
    private new EntryPointModel _model;

    public EntryPointController(EntryPointScriptableObject modelData, EntryPointView view) : base(modelData, view)
    {
        Init(modelData, view);
    }

    protected override void Init(IScriptableObject modelData, IView view)
    {
        _model = new EntryPointModel(modelData as EntryPointScriptableObject);
        _view = view as EntryPointView;
        InstantiateMainMenu();
        InstantiateSettingsMenu();
        InstantiateKeyBindSettingsMenu();
        InitInputSystem();
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    private void InstantiateMainMenu() => InstantiateChildObject(_model.MainMenuView.gameObject);
    private void InstantiateSettingsMenu() => InstantiateChildObject(_model.SettingsMenuView.gameObject);
    private void InstantiateKeyBindSettingsMenu() => InstantiateChildObject(_model.KeyBindSettingsMenuView.gameObject);
    private void InitInputSystem()
    {
        ModelList.FindModel(out KeyboardKeyBindSettingsModel model);
        new InputSystemController(model.KeyBindSettings);
    }
}

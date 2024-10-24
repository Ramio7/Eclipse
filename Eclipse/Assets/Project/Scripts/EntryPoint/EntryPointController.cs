public class EntryPointController : BaseGameObjectController
{
    private new EntryPointModel model;

    public EntryPointController(EntryPointScriptableObject modelData, EntryPointView view) : base(view)
    {
        Init(modelData, view);
    }

    protected void Init(IScriptableObject modelData, IView view)
    {
        base.Init(view);

        model = new EntryPointModel(modelData as EntryPointScriptableObject);
        base.view = view as EntryPointView;

        InstantiateMainMenu();
        InstantiateSettingsMenu();
        InstantiateKeyBindSettingsMenu();
        InstantiateLoadingScreen();
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    private void InstantiateMainMenu() => InstantiateChildObject(model.MainMenuView.gameObject);
    private void InstantiateSettingsMenu() => InstantiateChildObject(model.SettingsMenuView.gameObject);
    private void InstantiateKeyBindSettingsMenu() => InstantiateChildObject(model.KeyBindSettingsMenuView.gameObject);
    private void InstantiateLoadingScreen() => InstantiateChildObject(model.LoadingScreenView.gameObject);
}

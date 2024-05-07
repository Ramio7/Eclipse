public class EntryPointController : BaseController
{
    private new EntryPointModel _model;

    public EntryPointController(IView view, IScriptableObject modelData) : base(view)
    {
        var tempModelData = modelData as EntryPointScriptableObject;
        _model = new EntryPointModel(tempModelData);

        Init();
    }

    public override void Init()
    {
        InstantiateGame();
        InstantiateMainMenu();
        InstantiateSettingsMenu();
    }

    private void InstantiateGame() => InstantiateChildObject(_model.GameView);
    private void InstantiateMainMenu() => InstantiateChildObject(_model.MainMenuView);
    private void InstantiateSettingsMenu() => InstantiateChildObject(_model.SettingsMenuView);
}

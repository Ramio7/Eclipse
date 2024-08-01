using UnityEngine.SceneManagement;

public class EntryPointController : BaseGameObjectController
{
    private new EntryPointModel _model;

    public EntryPointController(EntryPointScriptableObject modelData, EntryPointView view) : base(modelData, view)
    {
        Init(modelData, view);
    }

    public override void Init(IScriptableObject modelData, IView view)
    {
        base.Init();
        _model = new EntryPointModel(modelData as EntryPointScriptableObject);
        _view = view as EntryPointView;
        SceneManager.activeSceneChanged += InitializeMenuObjects;

        if (SceneManager.GetActiveScene().buildIndex == (int)GameScens.MainMenu) InitializeMenuObjects();
    }

    public override void Dispose()
    {
        SceneManager.activeSceneChanged -= InitializeMenuObjects;

        base.Dispose();
    }

    private void InitializeMenuObjects()
    {
        InstantiateMainMenu();
        InstantiateSettingsMenu();
        InstantiateKeyBindSettingsMenu();
        InitInputSystem();
    }
    private void InitializeMenuObjects(Scene loadedScene, Scene unloadedScene)
    {
        if (loadedScene.buildIndex == (int)GameScens.MainMenu)
        {
            InstantiateMainMenu();
            InstantiateSettingsMenu();
            InstantiateKeyBindSettingsMenu();
            InitInputSystem();
        }
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

public class GameController : BaseController
{
    private new GameModel _model;
    private new GameView _view;

    public static GameController Instance;

    public GameController(IView view, IScriptableObject modelData) : base(view)
    {
        Instance = this;

        _view = view as GameView;
        _model = new(modelData);

        Init();
    }

    public override void Init()
    {
        InstantiateChildObject(_model.OverlayView.gameObject);
    }

    public override void Dispose()
    {
        _model?.Dispose();

        _model = null;
        _view = null;
    }

    public void StartGame()
    {
        _model.LoadGameScene();
    }

    public void ContinueGame()
    {

    }
}

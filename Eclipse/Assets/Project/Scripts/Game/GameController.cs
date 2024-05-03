public class GameController : BaseController
{
    private new GameModel _model;
    private new GameView _view;

    public static GameController Instance;

    public GameController(IView view, GameScriptableObject modelData) : base(view)
    {
        Instance = this;

        Init();
    }

    public override void Init()
    {
        base.Init();

        Instance = this;
    }

    public override void Dispose()
    {
        base.Dispose();

        _model?.Dispose();
        _model = null;
        _view = null;
    }

    public void StartGame()
    {
        _model.LoadGameScene();
        _model.ChangeCanvas(_view.GameLoaderCanvas);
    }

    public void ContinueGame()
    {
    }
}

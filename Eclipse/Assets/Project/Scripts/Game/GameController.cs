public class GameController : BaseGameObjectController
{
    private new GameModel _model;
    private new GameView _view;

    public GameController(GameScriptableObject modelData, GameView view) : base(modelData, view)
    {
        Init(modelData, view);
    }

    public override void Init(IScriptableObject data, IView view)
    {
        base.Init();
        _view = view as GameView;
        _model = new(data as GameScriptableObject);
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

public class GameController : BaseGameObjectController
{
    private new GameModel _model;
    private new GameView _view;

    public GameController(GameScriptableObject modelData, GameView view) : base(view)
    {
        Init(modelData, view);
    }

    protected void Init(IScriptableObject data, IView view)
    {
        base.Init(view);

        _view = view as GameView;
        _model = new(data as GameScriptableObject);

        InstantiateChildObject(_model.OverlayView.gameObject, _view.gameObject);
    }

    public override void Dispose()
    {
        base.Dispose();

        _view = null;
    }
}

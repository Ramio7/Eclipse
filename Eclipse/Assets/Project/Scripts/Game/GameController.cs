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

public class GameOverlayController : BaseGameObjectController
{
    private new GameOverlayView _view;
    private new GameOverlayModel _model;

    public GameOverlayController(GameOverlayScriptableObject data, GameOverlayView view) : base(data, view)
    {
        Init(data, view);
    }

    protected override void Init(IScriptableObject data, IView view)
    {
        _view = view as GameOverlayView;
        _model = new(data as GameOverlayScriptableObject, _view.Canvas);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

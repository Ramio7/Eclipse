public class GameOverlayController : BaseGameObjectController
{
    private new GameOverlayView _view;
    private new GameOverlayModel _model;

    public GameOverlayController(GameOverlayScriptableObject data, GameOverlayView view) : base(view)
    {
        Init(data, view);
    }

    protected void Init(GameOverlayScriptableObject data, IView view)
    {
        base.Init(view);
        _model = new(data);
        _view = view as GameOverlayView;
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

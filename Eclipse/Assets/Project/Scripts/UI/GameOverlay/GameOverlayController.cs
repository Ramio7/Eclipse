public class GameOverlayController : BaseGameObjectController
{
    private new GameOverlayView view;
    private new GameOverlayModel model;

    public GameOverlayController(GameOverlayScriptableObject data, GameOverlayView view) : base(view)
    {
        Init(data, view);
    }

    protected void Init(GameOverlayScriptableObject data, IView view)
    {
        base.Init(view);

        model = new(data);
        this.view = view as GameOverlayView;
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

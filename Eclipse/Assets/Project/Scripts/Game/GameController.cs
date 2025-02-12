public class GameController : BaseGameObjectController
{
    private new GameModel model;
    private new GameView view;

    public GameController(GameScriptableObject modelData, GameView view) : base(view)
    {
        Init(modelData, view);
    }

    protected void Init(IScriptableObject data, IView view)
    {
        base.Init(view);

        this.view = view as GameView;
        model = new(data as GameScriptableObject);

        InstantiateChildObject(model.OverlayView.gameObject, this.view.gameObject);
    }

    public override void Dispose()
    {
        base.Dispose();

        view = null;
    }
}

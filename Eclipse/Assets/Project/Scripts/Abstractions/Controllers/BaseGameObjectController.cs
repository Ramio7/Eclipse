public abstract class BaseGameObjectController : BaseController, IGameObjectController
{
    protected IView _view;

    public BaseGameObjectController(IScriptableObject data, IView view) : base()
    {
        _view = view;
    }

    public virtual void Init(IScriptableObject data, IView view)
    {
        base.Init();
    }

    public override void Dispose()
    {
        _view = null;
        base.Dispose();
    }
}

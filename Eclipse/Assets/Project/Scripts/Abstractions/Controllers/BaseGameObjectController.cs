public abstract class BaseGameObjectController : BaseController, IGameObjectController
{
    protected IView _view;

    public BaseGameObjectController(IView view) : base()
    {
        Init(view);
    }

    public virtual void Init(IView view)
    {
        _view = view;
    }

    public override void Dispose()
    {
        _view = null;
        base.Dispose();
    }
}

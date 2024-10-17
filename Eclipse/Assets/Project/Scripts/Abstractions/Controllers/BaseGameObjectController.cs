public abstract class BaseGameObjectController : BaseController
{
    protected IView _view;

    public BaseGameObjectController(IView view) : base()
    {
    }

    protected virtual void Init(IView view)
    {
        base.Init();

        _view = view;
    }

    public override void Dispose()
    {
        _view = null;
        base.Dispose();
    }
}

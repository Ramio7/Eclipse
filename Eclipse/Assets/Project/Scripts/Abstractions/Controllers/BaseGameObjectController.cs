public abstract class BaseGameObjectController : BaseController
{
    protected IView view;

    public BaseGameObjectController(IView view) : base()
    {
    }

    protected virtual void Init(IView view)
    {
        base.Init();

        this.view = view;
    }

    public override void Dispose()
    {
        view = null;
        base.Dispose();
    }
}

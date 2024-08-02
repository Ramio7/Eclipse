public abstract class BaseGameObjectController : BaseController
{
    protected IView _view;

    public BaseGameObjectController(IScriptableObject data, IView view) : base()
    {
        _view = view;
    }

    protected virtual void Init(IScriptableObject data, IView view)
    {
        base.Init();
    }
}

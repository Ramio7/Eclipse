public abstract class BaseScriptableObjectOrientedController : BaseController, IScriptableObjectOrientedController
{
    protected IScriptableObject _scriptableObject;

    public BaseScriptableObjectOrientedController(IScriptableObject scriptableObject) : base()
    {
    }

    public void Init(IScriptableObject scriptableObject)
    {
        base.Init();

        _scriptableObject = scriptableObject;
    }
}

public class BaseScriptableObjectOrientedController : BaseController, IScriptableObjectOrientedController
{
    protected IScriptableObject _scriptableObject;

    public BaseScriptableObjectOrientedController(IScriptableObject scriptableObject) : base()
    {
        _scriptableObject = scriptableObject;
    }

    public void Init(IScriptableObject scriptableObject)
    {
        _scriptableObject = scriptableObject;
    }
}

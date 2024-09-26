public class BaseScriptableObjectOrientedModel : BaseModel, IScriptableObjectOrientedModel
{
    protected IScriptableObject _scriptableObject;

    public BaseScriptableObjectOrientedModel(IScriptableObject scriptableObject) : base()
    {
        Init(scriptableObject);
    }

    public virtual void Init(IScriptableObject scriptableObject)
    {
        _scriptableObject = scriptableObject;
    }

    public override void Dispose()
    {
        base.Dispose();
        _scriptableObject = null;
    }
}

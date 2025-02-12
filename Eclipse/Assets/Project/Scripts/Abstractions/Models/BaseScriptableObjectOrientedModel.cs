public abstract class BaseScriptableObjectOrientedModel : BaseModel, IScriptableObjectOrientedModel
{
    protected IScriptableObject _scriptableObject;

    public BaseScriptableObjectOrientedModel(IScriptableObject scriptableObject) : base()
    {
    }

    public virtual void Init(IScriptableObject scriptableObject)
    {
        base.Init();

        _scriptableObject = scriptableObject;
    }

    public override void Dispose()
    {
        base.Dispose();
        _scriptableObject = null;
    }
}

public abstract class BaseModel : IModel
{
    public BaseModel(IScriptableObject data)
    {
    }

    protected virtual void Init(IScriptableObject modelData)
    {
        ModelList.RegisterModel(this);
    }

    public virtual void Dispose()
    {
    }
}

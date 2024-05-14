public abstract class BaseModel : IModel
{
    public BaseModel()
    {
    }

    protected abstract void Init(IScriptableObject modelData);

    public abstract void Dispose();
}

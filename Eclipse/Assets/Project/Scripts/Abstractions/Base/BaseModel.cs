public abstract class BaseModel : IModel
{
    public BaseModel()
    {
        
    }

    protected virtual void InitAsync()
    {
        ModelList.RegisterModel(this);
    }

    public virtual void Dispose()
    {
    }
}

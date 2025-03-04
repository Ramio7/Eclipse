public abstract class BaseModel : IModel
{
    public BaseModel()
    {
        
    }

    protected virtual void Init()
    {
        ModelList.RegisterModel(this);
    }

    public virtual void Dispose()
    {
    }
}

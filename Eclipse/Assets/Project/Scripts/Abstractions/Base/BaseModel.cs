public abstract class BaseModel : IModel
{
    public BaseModel()
    {
        Init();
    }

    protected virtual void Init()
    {
        ModelList.RegisterModel(this);
    }

    public virtual void Dispose()
    {
    }
}

public abstract class BaseStructOrientedModel : BaseModel
{
    protected BaseStructOrientedModel(IScriptableObject data, IStruct @struct) : base(data)
    {
    }

    protected virtual void Init(IScriptableObject data, IStruct @struct)
    {
        base.Init(data);
    }
}

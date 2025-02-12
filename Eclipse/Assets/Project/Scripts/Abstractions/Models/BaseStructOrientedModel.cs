public abstract class BaseStructOrientedModel : BaseModel, IStructOrientedModel
{
    protected IStruct m_struct;

    protected BaseStructOrientedModel(IStruct @struct) : base()
    {
        Init(@struct);
    }

    public virtual void Init(IStruct @struct)
    {
        base.Init();

        m_struct = @struct;
    }
}

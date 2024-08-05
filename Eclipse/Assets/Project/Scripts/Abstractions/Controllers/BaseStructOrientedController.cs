public class BaseStructOrientedController : BaseController, IStructOrientedController
{
    protected IStruct m_struct;

    public BaseStructOrientedController(IStruct @struct) : base()
    {
        Init(@struct);
    }

    public virtual void Init(IStruct @struct)
    {
        m_struct = @struct;
    }
}
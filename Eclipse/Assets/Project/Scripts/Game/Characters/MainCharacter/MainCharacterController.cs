public class MainCharacterController : BaseGameObjectController
{
    public MainCharacterController(IScriptableObject scriptableObject, MainCharacterView view) : base(view)
    {
        Init(scriptableObject, view);
    }

    protected void Init(IScriptableObject data, IView view)
    {
        base.Init(view);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

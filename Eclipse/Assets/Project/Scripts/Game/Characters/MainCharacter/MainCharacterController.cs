public class MainCharacterController : BaseGameObjectController
{
    public MainCharacterController(IScriptableObject scriptableObject, MainCharacterView view) : base(scriptableObject, view)
    {
        Init(scriptableObject, view);
    }

    public override void Init(IScriptableObject data, IView view)
    {
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
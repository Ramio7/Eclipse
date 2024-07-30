public class MainCharacterController : BaseGameObjectController
{
    public MainCharacterController(IScriptableObject scriptableObject, IView view) : base(scriptableObject, view)
    {
        base.Init();
    }

    public override void Dispose()
    {
        throw new System.NotImplementedException();
    }
}

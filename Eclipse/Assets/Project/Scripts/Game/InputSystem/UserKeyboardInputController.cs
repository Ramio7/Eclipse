public class UserKeyboardInputController : BaseInputSystemController
{
    protected new UserKeyboardInputModel model;

    public UserKeyboardInputController() : base()
    {
        Init();
    }

    protected override void Init()
    {
        model = new();

        base.Init();
    }

    private void InitUserInputProcess()
    {
        
    }
    
    private void DeinitUserInputProcess()
    {

    }
}

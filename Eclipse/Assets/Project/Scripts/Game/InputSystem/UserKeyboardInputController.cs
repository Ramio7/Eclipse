public class UserKeyboardInputController : BaseInputSystemController
{
    private new UserKeyboardInputModel model;

    public UserKeyboardInputController() : base()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        model = new();
    }

    private void InitUserInputProcess()
    {
        
    }
    
    private void DeinitUserInputProcess()
    {

    }
}

using UnityEngine;

public class BaseInputSystemController : BaseController
{
    public BaseInputSystemController() : base()
    {
        Init();
    }

    protected new void Init()
    {
        _model = new BaseInputSystemModel();

        EntryPointView.OnUpdate += TrackUserBaseInput;
        EntryPointView.OnUpdate += TrackUserAxisInput;
    }

    public override void Dispose()
    {
        base.Dispose();

        EntryPointView.OnUpdate -= TrackUserBaseInput;
        EntryPointView.OnUpdate -= TrackUserAxisInput;
    }

    private void TrackUserBaseInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && (GameStateMashine.Current == GameState.Game)
            || Input.GetKeyUp(KeyCode.Menu)) GameStateMashine.Instance.ChangeGameState(GameState.MainMenu);
    }

    private void TrackUserAxisInput()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            ArrayUtility<MoveAbility>.
                FindArrayElementOfType(AbilitiesAllocator.MainCharacterAbilities.ToArray(), out MoveAbility moveAbility);
            if (!moveAbility.IsInvoking.GetValue()) moveAbility.Invoke();
        }

        if (GameStateMashine.Current != GameState.Game)
        {
            //write code for menu buttons jumps
        }
    }
}

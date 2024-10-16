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

        EntryPointView.OnUpdate += TrackBaseInput;
        EntryPointView.OnUpdate += TrackAxisInput;
    }

    public override void Dispose()
    {
        base.Dispose();

        EntryPointView.OnUpdate -= TrackBaseInput;
        EntryPointView.OnUpdate -= TrackAxisInput;
    }

    private void TrackBaseInput()
    {
        if ((Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Menu)) 
            && (GameStateMashine.Current == GameState.Game))
            GameStateMashine.Instance.ChangeGameState(GameState.MainMenu);
    }

    private void TrackAxisInput()
    {
        var horizontalAxisValue = Input.GetAxis("Horizontal");
        var verticalAxisValue = Input.GetAxis("Vertical");

        if (horizontalAxisValue != 0)
        {
            ArrayUtility<MoveAbility>.
                FindArrayElementOfType(AbilitiesAllocator.MainCharacterAbilities.ToArray(), out MoveAbility moveAbility);
            if (!moveAbility.IsInvoking.GetValue()) moveAbility.Invoke();
        }

        if (verticalAxisValue != 0)
        {
            if (verticalAxisValue > 0)
            {
                ArrayUtility<JumpAbility>.FindArrayElementOfType(AbilitiesAllocator.MainCharacterAbilities.ToArray(), out JumpAbility jumpAbility);
                if (!jumpAbility.IsInvoking.GetValue()) jumpAbility.Invoke();
            }
            else if (verticalAxisValue < 0)
            {
                ArrayUtility<CrouchAbility>.FindArrayElementOfType(AbilitiesAllocator.MainCharacterAbilities.ToArray(), out CrouchAbility crouchAbility);
                if (!crouchAbility.IsInvoking.GetValue()) crouchAbility.Invoke();
            }
        }

        if (GameStateMashine.Current != GameState.Game)
        {
            //write code for menu buttons jumps
        }
    }
}

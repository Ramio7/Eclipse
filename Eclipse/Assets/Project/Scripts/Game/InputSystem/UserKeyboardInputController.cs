using UnityEngine;

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

        GameStateMashine.Instance.OnGameStateChanged += SwitchAbilitiesTracking;

        base.Init();
    }

    public override void Dispose()
    {
        if (GameStateMashine.Current == GameState.Game)
        {
            DeinitUserInputProcess();
        }

        if (GameStateMashine.Instance != null) GameStateMashine.Instance.OnGameStateChanged -= SwitchAbilitiesTracking;

        base.Dispose();
    }

    private void InitUserInputProcess()
    {
        GameEvents.OnFixedUpdate += model.InvokeMoveAbility;
        GameEvents.OnFixedUpdate += model.InvokeJumpAbility;
        GameEvents.OnFixedUpdate += AbilityCash.InvokeAbilities;
    }
    
    private void DeinitUserInputProcess()
    {
        GameEvents.OnFixedUpdate -= model.InvokeMoveAbility;
        GameEvents.OnFixedUpdate -= model.InvokeJumpAbility;
        GameEvents.OnFixedUpdate -= AbilityCash.InvokeAbilities;
    }

    private void SwitchAbilitiesTracking(GameState gameState)
    {
        if (gameState == GameState.Game)
        {
            InitUserInputProcess();
        }
        else
        {
            DeinitUserInputProcess();
        }
    }

    protected override void TrackKeyInput()
    {
        if (Event.current == null) return;
        if (Event.current.type == EventType.KeyUp)
        {
            model.SetKey(Event.current.keyCode);
        }
    }

    protected override void TrackAxisInput()
    {
        model.SetAxis(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}

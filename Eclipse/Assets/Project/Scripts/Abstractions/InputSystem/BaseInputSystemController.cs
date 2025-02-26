public abstract class BaseInputSystemController : BaseController
{
    protected new IInputSystemModel model;

    public BaseInputSystemController() : base()
    {
    }

    protected override void Init()
    {
        base.Init();

        if (GameStateMashine.Current is GameState.Game)
        {
            InitInputTracking();
        }

        GameStateMashine.Instance.OnGameStateChanged += SwitchInputTracking;
    }

    public override void Dispose()
    {
        base.Dispose();

        if (GameStateMashine.Current is GameState.Game)
        {
            DeinitInputTracking();
        }

        if (GameStateMashine.Instance != null) GameStateMashine.Instance.OnGameStateChanged -= SwitchInputTracking;
    }

    private void SwitchInputTracking(GameState gameState)
    {
        if (gameState == GameState.Game)
        {
            InitInputTracking();
        }
        else
        {
            DeinitInputTracking();
        }
    }

    private void InitInputTracking()
    {
        GameEvents.OnGuiUpdate += TrackAxisInput;
        GameEvents.OnGuiUpdate += TrackKeyInput;
    }

    private void DeinitInputTracking()
    {
        GameEvents.OnGuiUpdate -= TrackAxisInput;
        GameEvents.OnGuiUpdate -= TrackKeyInput;
    }

    protected abstract void TrackKeyInput();

    protected abstract void TrackAxisInput();
}

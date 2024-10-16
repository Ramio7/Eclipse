public class LoadingScreenView : BaseUIView
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        CanvasSelector.AddCanvas(GameState.LoadingScreen, this);
    }
}

public class LoadingScreenView : BaseUIView
{
    private void Start()
    {
        DontDestroyOnLoad(this);
        CanvasSelector.AddCanvas(GameState.LoadingScreen, this);
    }

    private void OnDestroy()
    {
    }
}

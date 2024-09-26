public class MainMenuModel : BaseScriptableObjectOrientedModel
{
    public MainMenuModel(MainMenuScriptableObject data) : base(data)
    {
        
    }

    public override void Init(IScriptableObject modelData)
    {
        
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public void ActivateSettingsMenu() => GameStateMashine.Instance.ChangeGameState(GameState.SettingsMenu);
    public void ActivateLoadingScreen() => GameStateMashine.Instance.ChangeGameState(GameState.LoadingScreen);
    public void ReturnToGame() => GameStateMashine.Instance.ChangeGameState(GameState.Game);
}

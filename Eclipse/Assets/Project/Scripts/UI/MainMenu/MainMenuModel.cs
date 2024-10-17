public class MainMenuModel : BaseScriptableObjectOrientedModel
{
    public MainMenuModel(MainMenuScriptableObject data) : base(data)
    {
        
    }

    public override void Init(IScriptableObject modelData)
    {
        base.Init(modelData);
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public void ActivateSettingsMenu() => GameStateMashine.Instance.ChangeGameSubState(GameMenuSubState.SettingsMenu);
    public void ActivateLoadingScreen() => GameStateMashine.Instance.ChangeGameState(GameState.LoadingScreen);
    public void ReturnToGame() => GameStateMashine.Instance.ChangeGameState(GameState.Game);
}

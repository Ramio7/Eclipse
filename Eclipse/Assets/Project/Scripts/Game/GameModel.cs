using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModel : BaseModel
{
    private GameState _gameState = GameState.Game;

    public GameModel(IScriptableObject gameData, Canvas gameUi) : base()
    {
        CanvasSelector.AddCanvas(_gameState, gameUi);
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public void LoadGameScene() => SceneManager.LoadSceneAsync(1);
}

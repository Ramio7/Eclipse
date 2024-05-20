using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModel : BaseModel
{
    private GameObject _girlPrefab;
    private GameOverlayView _overlayView;

    public GameObject GirlPrefab { get => _girlPrefab; }
    public GameOverlayView OverlayView { get => _overlayView; }

    public GameModel(IScriptableObject gameData) : base()
    {
        var tempGameData = gameData as GameScriptableObject;
        _girlPrefab = tempGameData.GirlPrefab;
        _overlayView = tempGameData.OverlayView;
    }

    protected override void Init(IScriptableObject modelData)
    {
        
    }

    public override void Dispose()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync((int)GameScens.Village);
        GameStateMashine.Instance.ChangeGameState(GameState.Village);
    }
}

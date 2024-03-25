using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModel : BaseModel
{
    private Canvas _activeCanvas;

    public GameModel() : base()
    {
    }

    public void LoadGameScene() => SceneManager.LoadSceneAsync(1);
    public void ChangeCanvas(Canvas canvasToActivate)
    {
        if (_activeCanvas != null) _activeCanvas.enabled = false;
        _activeCanvas = canvasToActivate;
    }
}

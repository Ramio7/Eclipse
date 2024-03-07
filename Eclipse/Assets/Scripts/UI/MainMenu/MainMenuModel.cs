using UnityEngine;
using UnityEngine.UI;

public class MainMenuModel : BaseModel
{
    private Canvas _activeCanvas;

    public MainMenuModel(MainMenuScriptableObject data, Canvas startCanvas) : base()
    {
        _activeCanvas = startCanvas;
    }

    public override void Dispose()
    {
        _activeCanvas = null;
    }

    public void ChangeCanvas(Canvas canvasToActivate)
    {
        _activeCanvas.gameObject.SetActive(false);
        _activeCanvas = canvasToActivate;
        canvasToActivate.gameObject.SetActive(true);
    }

    public void SwitchActiveButton(Button buttonToActivate, Button buttonToDisable)
    {
        buttonToActivate.gameObject.SetActive(true);
        buttonToDisable.gameObject.SetActive(false);
    }
}

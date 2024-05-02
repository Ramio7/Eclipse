using UnityEngine;
using UnityEngine.UI;

public class MainMenuModel : BaseModel, IUIModel
{
    private Canvas _menuCanvas;

    public MainMenuModel(MainMenuScriptableObject data, Canvas menuCanvas) : base()
    {
        _menuCanvas = menuCanvas;
    }

    public override void Dispose()
    {
        _menuCanvas = null;
    }

    public void ChangeCanvas(Canvas canvasToActivate)
    {
        _menuCanvas.enabled = false;
        canvasToActivate.enabled = true;
    }

    public void SwitchActiveButton(Button buttonToActivate, Button buttonToDisable)
    {
        buttonToActivate.gameObject.SetActive(true);
        buttonToDisable.gameObject.SetActive(false);
    }
}

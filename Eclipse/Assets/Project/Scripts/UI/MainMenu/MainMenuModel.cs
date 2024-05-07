using UnityEngine;
using UnityEngine.UI;

public class MainMenuModel : BaseModel, IUIModel
{
    private GameState _gameState = GameState.MainMenu;

    public MainMenuModel(MainMenuScriptableObject data, Canvas menuCanvas) : base()
    {
        CanvasSelector.AddCanvas(_gameState, menuCanvas);
    }

    public override void Dispose()
    {
        
    }

    public void SwitchActiveButton(Button buttonToActivate, Button buttonToDisable)
    {
        buttonToActivate.gameObject.SetActive(true);
        buttonToDisable.gameObject.SetActive(false);
    }
}

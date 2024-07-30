using UnityEngine;
using UnityEngine.UI;

public class MainMenuModel : BaseUIModel
{
    private GameState _gameState = GameState.MainMenu;

    public MainMenuModel(MainMenuScriptableObject data, Canvas menuCanvas) : base(data, menuCanvas)
    {
        Init(data, menuCanvas);
    }

    protected override void Init(IScriptableObject modelData)
    {
        throw new System.Exception("Wrong Init method used");
    }

    protected override void Init(IScriptableObject modelData, Canvas canvas)
    {
        ModelList.RegisterModel(this);

        CanvasSelector.AddCanvas(_gameState, canvas);
    }

    public override void Dispose()
    {
        CanvasSelector.RemoveCanvas(_gameState);
    }

    public void SwitchActiveButton(Button buttonToActivate, Button buttonToDisable)
    {
        buttonToActivate.gameObject.SetActive(true);
        buttonToDisable.gameObject.SetActive(false);
    }
}

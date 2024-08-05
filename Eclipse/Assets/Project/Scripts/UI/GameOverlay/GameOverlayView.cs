using UnityEngine;

public class GameOverlayView : BaseUIView
{
    [SerializeField] private GameOverlayScriptableObject _gameOverlayDefaults;

    private GameOverlayController _controller;

    private void Awake()
    {
        CanvasSelector.AddCanvas(GameState.Game, this);
        _controller = new(_gameOverlayDefaults, this);
        CanvasSelector.Instance.SwitchCanvas(GameState.Game);
    }

    private void OnDestroy()
    {
    }
}

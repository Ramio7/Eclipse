using UnityEngine;

public class GameOverlayView : BaseUIView
{
    [SerializeField] private GameOverlayScriptableObject _gameOverlayDefaults;

    private GameOverlayController _controller;

    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        CanvasSelector.AddCanvas(GameState.Game, this);
        _controller = new(_gameOverlayDefaults, this);
        CanvasSelector.Instance.SwitchCanvas(GameState.Game);
    }

    private void OnDestroy()
    {
        _controller = null;
    }
}

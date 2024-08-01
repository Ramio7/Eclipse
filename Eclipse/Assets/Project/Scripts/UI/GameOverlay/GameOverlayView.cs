using UnityEngine;

public class GameOverlayView : BaseUIView
{
    [SerializeField] private GameOverlayScriptableObject _gameOverlayDefaults;

    private GameOverlayController _controller;

    private void Awake()
    {
        _controller = new(_gameOverlayDefaults, this);
    }
}

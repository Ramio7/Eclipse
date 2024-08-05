using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelector: IDisposable
{
    private static Dictionary<GameState, IUIView> _canvasDictionary = new();
    private Canvas _activeCanvas;

    public static CanvasSelector Instance;

    public CanvasSelector()
    {
        if (Instance == null)
        {
            Instance = this;

            InitCanvas(GameState.MainMenu);
            InitCanvas(GameState.SettingsMenu);
            InitCanvas(GameState.KeyBindMenu);
            InitCanvas(GameState.Game);
            InitCanvas(GameState.Pause);
            InitCanvas(GameState.LoadingScreen);
            GameStateMashine.Instance.OnGameStateChanged += SwitchCanvas;
        }
    }

    public void Dispose()
    {
        _canvasDictionary.Clear();

        _canvasDictionary = null;

        if (GameStateMashine.Instance != null) GameStateMashine.Instance.OnGameStateChanged -= SwitchCanvas;
    }

    private void InitCanvas(GameState gameState)
    {
        if (_canvasDictionary.ContainsKey(gameState)) return;
        _canvasDictionary.Add(gameState, null);
    }

    public static void AddCanvas(GameState state, IUIView view)
    {
        _canvasDictionary[state] = view;
    }

    public void SwitchCanvas(GameState state)
    {
        if (_activeCanvas != null) _activeCanvas.enabled = false;
        _activeCanvas = _canvasDictionary[state].Canvas;
        _activeCanvas.enabled = true;
    }
}

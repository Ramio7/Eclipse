using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSelector: IDisposable
{
    private static Dictionary<GameState, Canvas> _canvasDictionary = new();
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

    public static void AddCanvas(GameState state, Canvas canvas)
    {
        _canvasDictionary[state] = canvas;
    }

    public static void RemoveCanvas(GameState state)
    {
        _canvasDictionary.Remove(state);
    }

    public void SwitchCanvas(GameState state)
    {
        if (_activeCanvas == null)
        {
            _activeCanvas = _canvasDictionary[GameState.MainMenu];
            _activeCanvas.enabled = true;
            return;
        }
        _activeCanvas.enabled = false;
        _activeCanvas = _canvasDictionary[state];

        if (_activeCanvas == _canvasDictionary[GameState.MainMenu] && SceneManager.GetActiveScene().buildIndex != (int)GameScens.MainMenu) _activeCanvas.enabled = false;
        else _activeCanvas.enabled = true;
    }
}

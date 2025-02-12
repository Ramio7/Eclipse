using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelector: IDisposable
{
    private static Dictionary<GameState, IUIView> _gameCanvasDictionary = new();
    private static Dictionary<GameMenuSubState, IUIView> _gameSubCanvasDictionary = new();

    private Canvas _activeCanvas;

    public static CanvasSelector Instance;

    public CanvasSelector()
    {
        if (Instance == null)
        {
            Instance = this;

            GameStateMashine.Instance.OnGameStateChanged += SwitchCanvas;
            GameStateMashine.Instance.OnGameMenuStateChanged += SwitchCanvas;
        }
    }

    public void Dispose()
    {
        _gameCanvasDictionary.Clear();

        _gameCanvasDictionary = null;

        if (GameStateMashine.Instance != null)
        {
            GameStateMashine.Instance.OnGameStateChanged -= SwitchCanvas;
            GameStateMashine.Instance.OnGameMenuStateChanged -= SwitchCanvas;
        }
    }

    public static void AddCanvas(GameState state, IUIView view)
    {
        if (_gameCanvasDictionary.ContainsKey(state)) _gameCanvasDictionary[state] = view;
        else _gameCanvasDictionary.Add(state, view);
    }

    public static void AddCanvas(GameMenuSubState state, IUIView view)
    {
        if (_gameSubCanvasDictionary.ContainsKey(state)) _gameSubCanvasDictionary[state] = view;
        else _gameSubCanvasDictionary.Add(state, view);
    }

    public void SwitchCanvas(GameState state)
    {
        if (_activeCanvas != null) _activeCanvas.enabled = false;
        _activeCanvas = _gameCanvasDictionary[state].Canvas;
        _activeCanvas.enabled = true;
    }

    public void SwitchCanvas(GameMenuSubState state)
    {
        if (_activeCanvas != null) _activeCanvas.enabled = false;
        _activeCanvas = _gameSubCanvasDictionary[state].Canvas;
        _activeCanvas.enabled = true;
    }
}

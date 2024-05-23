using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelector: IDisposable
{
    private static Dictionary<GameState, Canvas> _canvasDictionary = new();
    private static Canvas _activeCanvas;

    public static CanvasSelector Instance;

    public CanvasSelector()
    {
        if (Instance == null)
        {
            Instance = this;

            InitCanvas(GameState.MainMenu);
            InitCanvas(GameState.SettingsMenu);
            InitCanvas(GameState.KeyBindMenu);
            InitCanvas(GameState.Village);
            InitCanvas(GameState.SacredForest);
            InitCanvas(GameState.DarkForest);
            InitCanvas(GameState.BearsBreechField);
            InitCanvas(GameState.SpruceForest);
            InitCanvas(GameState.SnowyMountains);
            GameStateMashine.Instance.OnGameStateChanged += SwitchCanvas;
        }
    }

    public void Dispose()
    {
        _canvasDictionary.Clear();

        _canvasDictionary = null;

        GameStateMashine.Instance.OnGameStateChanged -= SwitchCanvas;
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
        }
        _activeCanvas.enabled = false;
        _activeCanvas = _canvasDictionary[state];
        _activeCanvas.enabled = true;
    }
}

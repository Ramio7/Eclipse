using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelector: IDisposable
{
    private static Dictionary<GameState, Canvas> _canvasDictionary = new();
    private static Canvas _activeCanvas;

    public CanvasSelector()
    {
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
        GameStateMashine.Instance.ChangeGameState(GameState.MainMenu);
    }

    private static void InitCanvas(GameState gameState)
    {
        _canvasDictionary.Add(gameState, null);
    }

    public void Dispose()
    {
        _canvasDictionary.Clear();

        _canvasDictionary = null;

        GameStateMashine.Instance.OnGameStateChanged -= SwitchCanvas;
    }

    public static void AddCanvas(GameState state, Canvas canvas)
    {
        _canvasDictionary[state] = canvas;
    }

    public static void RemoveCanvas(GameState state)
    {
        _canvasDictionary.Remove(state);
    }

    private void SwitchCanvas(GameState state)
    {
        _activeCanvas.enabled = false;
        _activeCanvas = _canvasDictionary[state];
        _activeCanvas.enabled = true;
    }
}

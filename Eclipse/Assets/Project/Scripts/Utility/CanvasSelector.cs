using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelector: IDisposable
{
    private static Dictionary<GameState, Canvas> _canvasDictionary = new();
    private static Canvas _activeCanvas;

    public CanvasSelector()
    {
        _canvasDictionary.Add(GameState.MainMenu, null);
        _canvasDictionary.Add(GameState.SettingsMenu, null);
        _canvasDictionary.Add(GameState.Game, null);
    }

    public void Dispose()
    {
        _canvasDictionary.Clear();

        _canvasDictionary = null;
    }

    public static void AddCanvas(GameState state, Canvas canvas)
    {
        _canvasDictionary[state] = canvas;
    }

    public static void RemoveCanvas(GameState state)
    {
        _canvasDictionary.Remove(state);
    }

    public static void SwitchCanvas(GameState state)
    {
        _activeCanvas.enabled = false;
        _activeCanvas = _canvasDictionary[state];
        _activeCanvas.enabled = true;
    }
}

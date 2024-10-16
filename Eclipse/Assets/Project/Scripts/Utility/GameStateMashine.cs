using System;

public class GameStateMashine : IDisposable
{
    public static GameState Current;
    public static GameMenuSubState CurrentGameMenuState;

    public event Action<GameState> OnGameStateChanged;
    public event Action<GameMenuSubState> OnGameMenuStateChanged;

    public static GameStateMashine Instance;

    public GameStateMashine()
    {
        Init();
    }

    public void Init()
    {
        Instance = this;
    }

    public void Dispose()
    {
        Instance = null;
    }

    public void ChangeGameState(GameState state)
    {
        Current = state;
        OnGameStateChanged?.Invoke(state);
    }

    public void ChangeGameSubState(GameMenuSubState state)
    {
        CurrentGameMenuState = state;
        OnGameMenuStateChanged?.Invoke(state);
    }
}

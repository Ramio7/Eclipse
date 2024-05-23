using System;

public class GameStateMashine : IInitiable, IDisposable
{
    public static GameState Current;

    public event Action<GameState> OnGameStateChanged;

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
}

using System;
using Unity.Collections;
using Unity.Jobs;

public struct GameTimerFactory : IJobParallelFor, IDisposable, IInitiable
{
    private NativeList<GameTimer> _timersList;
    private int _timerCount;
    [WriteOnly] private NativeArray<DateTime> _currentTime;

    public static GameTimerFactory Instance { get; private set; }

    public GameTimerFactory(DateTime currentTime)
    {
        _currentTime = new(1, Allocator.Persistent);
        _currentTime[0] = currentTime;
        _timersList = new();
        _timerCount = 0;

        Init();
    }

    public void Execute(int index)
    {
        if (_timersList.IsEmpty) return;


    }


    public void Dispose()
    {
        GameEvents.OnUpdate -= UpdateTime;

        _currentTime.Dispose();
        _timersList.Dispose();
    }

    private void Init()
    {
        Instance = this;
        GameEvents.OnUpdate += UpdateTime;
    }

    public void AddTimer(int timerDurationMilliseconds)
    {
        _timersList.Add(new GameTimer(timerDurationMilliseconds, _currentTime));
    }

    private void UpdateTime()
    {
        _currentTime[0] = DateTime.Now;
    }
}

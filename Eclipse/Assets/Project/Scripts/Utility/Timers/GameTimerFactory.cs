using System;
using Unity.Collections;
using Unity.Jobs;

public struct GameTimerFactory : IJobParallelFor, IDisposable, IInitiable
{
    private NativeList<GameTimer> _timersList;
    private NativeArray<DateTime> _currentTime;

    public static GameTimerFactory Instance { get; private set; }
    public NativeList<GameTimer> TimerList { readonly get => _timersList; private set => _timersList = value; }

    public GameTimerFactory(DateTime currentTime)
    {
        _currentTime = new(1, Allocator.Persistent);
        _currentTime[0] = currentTime;
        _timersList = new(20, Allocator.Persistent);

        Init();
    }

    public void Execute(int index)
    {
        var currentTimer = _timersList[index];

        if (currentTimer.IsExpired[0]) DeleteTimer(index, currentTimer);
        else
        {
            currentTimer.Execute();
            currentTimer.UpdateTimeAsync(_currentTime[0]);
        }
    }

    private void Init()
    {
        Instance = this;
        GameEvents.OnFixedUpdate += UpdateTime;
    }

    public void Dispose()
    {
        GameEvents.OnFixedUpdate -= UpdateTime;

        _currentTime.Dispose();
        _timersList.Dispose();
    }

    public void AddTimer(int timerDurationMilliseconds)
    {
        var newTimer = new GameTimer(timerDurationMilliseconds, _currentTime);
        if (_timersList.Length == _timersList.Capacity) _timersList.Capacity++;
        _timersList.AsParallelWriter().AddNoResize(newTimer);
    }

    public void AddTimer(GameTimer gameTimer)
    {
        if (_timersList.Length == _timersList.Capacity) _timersList.Capacity++;
        _timersList.AsParallelWriter().AddNoResize(gameTimer);
    }

    private void DeleteTimer(int timerIndex, GameTimer gameTimer)
    {
        _timersList.RemoveAt(timerIndex);
        gameTimer.Dispose();
    }

    private void UpdateTime()
    {
        if (_currentTime[0] == DateTime.Now) return;

        _currentTime[0] = DateTime.Now;
    }
}

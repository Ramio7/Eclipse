using System;
using Unity.Collections;
using Unity.Jobs;

public struct GameTimer : IJob, IDisposable
{
    private bool _isExpired;
    private readonly DateTime _expireTime;

    [ReadOnly] public NativeArray<DateTime> CurrentTime;

    public bool IsExpired { get => _isExpired; private set => _isExpired = value; }

    public GameTimer(int timerDurationMilliseconds, NativeArray<DateTime> currentTime) : this()
    {
        _expireTime = currentTime[0].AddMilliseconds(timerDurationMilliseconds);
        CurrentTime = currentTime;
        _isExpired = false;
    }

    public void Execute()
    {
        if (_isExpired) return;

        if (CurrentTime[0] >= _expireTime) _isExpired = true; 
    }

    public void Dispose()
    {
        
    }

    public void UpdateTimeAsync(DateTime curentTime)
    {
        CurrentTime[0] = curentTime;
    }
}

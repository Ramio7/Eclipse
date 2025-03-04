using System;
using Unity.Collections;
using Unity.Jobs;

public struct GameTimer : IJob, IDisposable
{
    private NativeArray<bool> _isExpired;
    private NativeArray<bool> _isDisposed;
    private readonly DateTime _expireTime;

    public NativeArray<DateTime> CurrentTime;
    public NativeArray<bool> IsExpired { readonly get => _isExpired; private set => _isExpired = value; }
    public NativeArray<bool> IsDisposed { readonly get => _isDisposed; private set => _isDisposed = value; }

    public GameTimer(int timerDurationMilliseconds, NativeArray<DateTime> currentTime) : this()
    {
        _expireTime = currentTime[0].AddMilliseconds(timerDurationMilliseconds);

        CurrentTime = new(1, Allocator.Persistent);
        CurrentTime[0] = currentTime[0];

        IsExpired = new(1, Allocator.Persistent);
        _isExpired[0] = false;

        IsDisposed = new(1, Allocator.Persistent);
        _isDisposed[0] = false;
    }

    public GameTimer(int timerDurationMilliseconds) : this()
    {
        _expireTime = DateTime.Now.AddMilliseconds(timerDurationMilliseconds);

        CurrentTime = new(1, Allocator.Persistent);
        CurrentTime[0] = DateTime.Now;

        IsExpired = new(1, Allocator.Persistent);
        _isExpired[0] = false;

        IsDisposed = new(1, Allocator.Persistent);
        _isDisposed[0] = false;
    }

    public void Execute()
    {
        if (_isExpired[0]) return;

        if (CurrentTime[0] >= _expireTime) _isExpired[0] = true;
    }

    public void Dispose()
    {
        CurrentTime.Dispose();
        _isDisposed[0] = true;
    }

    public void UpdateTimeAsync(DateTime curentTime)
    {
        CurrentTime[0] = curentTime;
    }
}

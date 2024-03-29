using System;
using UnityEngine.Events;

public class ReactiveProperty<T> : IDisposable
{
    private T _value;

    public UnityEvent<T> OnValueChanged = new();

    public ReactiveProperty(T value)
    {
        _value = value;
    }

    public void Dispose()
    {
        _value = default;
        OnValueChanged.RemoveAllListeners();
        OnValueChanged = null;
    }

    public T GetValue() => _value;

    public void SetValue(T value)
    {
        if (_value.ToString() == value.ToString()) return;
        _value = value;
        OnValueChanged?.Invoke(value);
    }
}

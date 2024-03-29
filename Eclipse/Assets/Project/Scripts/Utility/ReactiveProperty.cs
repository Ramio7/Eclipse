using System;
using UnityEngine.Events;

public class ReactiveProperty<T>
{
    private T _value;

    public UnityEvent<T> OnValueChanged;

    public ReactiveProperty(T value)
    {
        _value = value;
    }

    public T GetValue() => _value;

    public void SetValue(T value)
    {
        if (_value.ToString() == value.ToString()) return;
        _value = value;
        OnValueChanged?.Invoke(value);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class BaseMonoobjectsPanelView<T> : BaseUIView, IMonoobjectsPanelView<T>
{
    [SerializeField] private List<T> _objects = new();
    public List<T> Objects { get => _objects; private set => _objects = value; }

    private void Awake()
    {
        var tiesInPanel = GetComponentsInChildren<T>();
        for (int i = 0; i < tiesInPanel.Length; i++) _objects.Add(tiesInPanel[i]);
    }

    private void OnDestroy() => _objects.Clear();
}

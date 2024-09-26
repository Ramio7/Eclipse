using System.Collections.Generic;
using UnityEngine;

public class BaseMonoobjectsPanelView<T> : BaseUIView, IMonoobjectsPanelView<T>
{
    [SerializeField] private List<T> _objects = new();
    public List<T> Objects { get => _objects; protected set => _objects = value; }

    private void Awake()
    {
        var objectsInPanel = GetComponentsInChildren<T>();
        for (int i = 0; i < objectsInPanel.Length; i++) _objects.Add(objectsInPanel[i]);
    }

    private void OnDestroy() => _objects.Clear();
}

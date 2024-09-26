using UnityEngine;

public interface IUIView : IView
{
    Canvas Canvas { get; }
    IUIView Instance { get; }

    virtual void Init() { }
}

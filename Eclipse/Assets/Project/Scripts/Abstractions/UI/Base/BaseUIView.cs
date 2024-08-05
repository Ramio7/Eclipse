using UnityEngine;

public class BaseUIView : BaseView, IUIView
{
    protected Canvas _canvas;

    public Canvas Canvas
    {
        get
        {
            if (TryGetComponent(out Canvas canvas)) { return _canvas = canvas; }
            else return _canvas = GetComponentInChildren<Canvas>();
        }

        private set => _canvas = value;
    }

    private void OnDestroy()
    {
        Canvas = null;
    }
}

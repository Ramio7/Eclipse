using UnityEngine;

public class BaseUIView : BaseView, IUIView
{
    public Canvas Canvas
    {
        get
        {
            if (TryGetComponent(out Canvas canvas)) return canvas;
            else return GetComponentInChildren<Canvas>();
        }

        private set => Canvas = value;
    }

    private void OnDestroy()
    {
        Canvas = null;
    }
}

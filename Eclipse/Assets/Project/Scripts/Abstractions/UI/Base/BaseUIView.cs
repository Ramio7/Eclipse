using UnityEngine;

public class BaseUIView : BaseView, IUIView
{
    protected Canvas _canvas;
    protected IUIView _instance;

    public Canvas Canvas
    {
        get
        {
            if (TryGetComponent(out Canvas canvas)) { return _canvas = canvas; }
            else return _canvas = GetComponentInChildren<Canvas>();
        }

        private set => _canvas = value;
    }

    public IUIView Instance { get => _instance; protected set => _instance = value; }

    protected virtual void Init() 
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);
        }
        else if (Instance.GameObject != this) Destroy(this);
    }

    private void OnDestroy()
    {
        Instance = null;
        Canvas = null;
    }
}

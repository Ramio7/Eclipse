using UnityEngine;

public abstract class BaseUIModel : BaseModel, IUIModel
{
    protected Canvas _canvas;

    public Canvas Canvas { get => _canvas; private set => _canvas = value; }

    public BaseUIModel(IScriptableObject modelData, Canvas canvas) : base(modelData)
    {
        _canvas = canvas;
    }

    protected abstract void Init(IScriptableObject modelData, Canvas canvas);
}

using UnityEngine;

public class BaseInputSystemModel : BaseModel
{
    protected KeyCode _lastKeyInput;
    protected float _horizontalAxis;

    public BaseInputSystemModel() : base()
    {
        Init();
    }

    protected new void Init()
    {
    }

    public override void Dispose()
    {
        
    }
}

using UnityEngine;

public abstract class BaseInputSystemModel : BaseModel
{
    protected KeyCode lastKeyInput;
    protected KeyCode currentKeyOutput;
    protected float horizontalAxis;
    protected float verticalAxis;

    public KeyCode LastKeyInput { get => lastKeyInput; set => lastKeyInput = value; }
    public KeyCode CurrentKeyOutput { get => currentKeyOutput; set => currentKeyOutput = value; }
    public float HorizontalAxis { get => horizontalAxis; set => horizontalAxis = value; }
    public float VerticalAxis { get => verticalAxis; set => verticalAxis = value; }

    public BaseInputSystemModel() : base()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        lastKeyInput = KeyCode.None;
        currentKeyOutput = KeyCode.None;
        horizontalAxis = 0;
        verticalAxis = 0;
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

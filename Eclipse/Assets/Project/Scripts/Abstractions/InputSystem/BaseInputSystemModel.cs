using UnityEngine;

public abstract class BaseInputSystemModel : BaseModel, IInputSystemModel
{
    protected ReactiveProperty<KeyCode> lastKeyInput;
    protected ReactiveProperty<KeyCode> currentKeyOutput;
    protected ReactiveProperty<float> horizontalAxis;
    protected ReactiveProperty<float> verticalAxis;

    public KeyCode LastKeyInput { get => lastKeyInput.GetValue(); set => lastKeyInput.SetValue(value); }
    public KeyCode CurrentKeyOutput { get => currentKeyOutput.GetValue(); set => currentKeyOutput.SetValue(value); }
    public float HorizontalAxis { get => horizontalAxis.GetValue(); set => horizontalAxis.SetValue(value); }
    public float VerticalAxis { get => verticalAxis.GetValue(); set => verticalAxis.SetValue(value); }

    public BaseInputSystemModel() : base()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        lastKeyInput = new(KeyCode.None);
        currentKeyOutput = new(KeyCode.None);
        horizontalAxis = new(0);
        verticalAxis = new(0);
    }

    public override void Dispose()
    {
        base.Dispose();

        lastKeyInput.Dispose();
        currentKeyOutput.Dispose();
        horizontalAxis.Dispose();
        verticalAxis.Dispose();
    }

    public void GetKey(KeyCode keyCode)
    {
        lastKeyInput.SetValue(currentKeyOutput.GetValue());
        currentKeyOutput.SetValue(keyCode);
    }

    public void GetAxis(float horizontalAxisValue, float verticalAxisValue)
    {
        horizontalAxis.SetValue(horizontalAxisValue);
        verticalAxis.SetValue(verticalAxisValue);
    }
}

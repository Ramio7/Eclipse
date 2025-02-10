using UnityEngine;

public abstract class BaseInputSystemController : BaseController
{
    protected new IInputSystemModel model;

    public BaseInputSystemController() : base()
    {
    }

    protected override void Init()
    {
        base.Init();

        EntryPointView.OnUpdate += TrackKeyInput;
        EntryPointView.OnUpdate += TrackAxisInput;
    }

    public override void Dispose()
    {
        base.Dispose();

        EntryPointView.OnUpdate -= TrackKeyInput;
        EntryPointView.OnUpdate -= TrackAxisInput;
    }

    private void TrackKeyInput()
    {
        if (Event.current == null) return;
        if (Event.current.type == EventType.KeyUp)
        {
            model.GetKey(Event.current.keyCode);
        }
    }

    private void TrackAxisInput() => model.GetAxis(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
}

using UnityEngine;

public abstract class BaseInputSystemController : BaseController
{
    protected BaseInputSystemModel model;

    public BaseInputSystemController() : base()
    {
        Init();
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
        if (Event.current.type == EventType.KeyDown) model.GetKey(Event.current.keyCode);
    }

    private void TrackAxisInput() => model.GetAxis(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
}

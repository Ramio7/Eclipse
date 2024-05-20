using UnityEngine;

public class InputSystemController : BaseController
{
    private new InputSystemView _view;
    private new InputSystemModel _model;

    private ICharacter _character;

    private KeyboardKeyBindSettings _keyBindSettings = new();

    public KeyboardKeyBindSettings KeyBindSettings { get => _keyBindSettings; set => _keyBindSettings = value; }
    public ICharacter Character { get => _character; set => _character = value; }

    public InputSystemController(IView view, KeyboardKeyBindSettings keyBindSettings) : base(view)
    {
        _view = view as InputSystemView;
        _keyBindSettings.Set(keyBindSettings);
    }

    public override void Init()
    {
        StartInputTracking();
    }

    public override void Dispose()
    {
        StopInputTracking();

        _model.Dispose();
        _keyBindSettings.Dispose();

        _model = null;
        _view = null;
    }

    private void StartInputTracking()
    {
        EntryPointView.OnUpdate += TrackUserAbilitiesInput;
        EntryPointView.OnUpdate += TrackUserBaseInput;
    }

    private void StopInputTracking()
    {
        EntryPointView.OnUpdate -= TrackUserAbilitiesInput;
        EntryPointView.OnUpdate -= TrackUserBaseInput;
    }

    private void TrackUserAbilitiesInput()
    {
        foreach (var key in _keyBindSettings.Keys.Values)
        {
            if (Input.GetKeyUp(key)) _model.KeysMethodsPairs[key].Method.Invoke();
        }
    }

    private void TrackUserBaseInput()
    {
        if (Input.GetAxis("Horizontal") != 0) _character.Rigidbody.AddForce(new(Input.GetAxis("Horizontal"), 0, 0));
    }
}

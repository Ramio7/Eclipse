using System.Threading.Tasks;
using UnityEngine;

public class InputSystemController : BaseStructOrientedController
{
    private ReactiveProperty<ICharacter> _character = new(EntryPointView.Instance.MainScreenCharacter);

    private KeyboardKeyBindSettings _keyBindSettings = new();

    public ICharacter Character { get => _character.GetValue(); set => _character.SetValue(value); }

    public InputSystemController(KeyboardKeyBindSettings keyBindSettings) : base(keyBindSettings)
    {
        base.Init(keyBindSettings);
    }

    public override void Init(IStruct @struct)
    {
        base.Init();
        _keyBindSettings.Set((KeyboardKeyBindSettings)@struct);
        _model = new InputSystemModel(@struct);
        StartInputTracking();
        InitCharacter();
    }
    private async void InitCharacter()
    {
        var tempTask = AwaitForCharacterInitiationAsync();
        await Task.Run(() => tempTask);
        var model = _model as InputSystemModel;
        _character.OnValueChanged.AddListener(model.SwitchCharacter);
    }

    public override void Dispose()
    {
        StopInputTracking();

        if (_model != null)
        {
            var model = _model as InputSystemModel;
            _character.OnValueChanged.RemoveListener(model.SwitchCharacter);
        }

        base.Dispose();
        _keyBindSettings.Dispose();
    }

    private Task AwaitForCharacterInitiationAsync()
    {
        while (AbilitiesAllocator.Instance == null) return Task.Delay(100);
        while (AbilitiesAllocator.CharactersAbilitiesDictionary.Count == 0) return Task.Delay(100);
        return Task.CompletedTask;
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
        if (GameStateMashine.Current != GameState.Game) return;
        var model = _model as InputSystemModel;
        foreach (var key in _keyBindSettings.Keys.Values)
        {
            if (Input.GetKeyUp(key)) model.KeysMethodsPairs[key].Method.Invoke();
        }
    }

    private void TrackUserBaseInput()
    {
        TrackHorizontalAxisInput();

        if (Input.GetKeyUp(KeyCode.Escape) && (GameStateMashine.Current != GameState.MainMenu))
            GameStateMashine.Instance.ChangeGameState(GameState.MainMenu);
        else if (Input.GetKeyUp(KeyCode.Escape) && GameStateMashine.Current == GameState.MainMenu)

#if UNITY_EDITOR
            Debug.Break();
#else
            Application.Quit();
#endif

        if (Input.GetKeyUp(KeyCode.LeftAlt) && Input.GetKeyUp(KeyCode.F4))

#if UNITY_EDITOR
            Debug.Break();
#else
            Application.Quit();
#endif

    }

    private void TrackHorizontalAxisInput()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            var rigidbody = _character.GetValue().Rigidbody;
            rigidbody.AddForce(new(Input.GetAxis("Horizontal"), 0));
            rigidbody.velocity = new(0, rigidbody.velocity.y);
        }
    }
}

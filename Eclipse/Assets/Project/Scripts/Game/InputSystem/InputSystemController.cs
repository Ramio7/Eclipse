using System.Threading.Tasks;
using UnityEngine;

public class InputSystemController : BaseController
{
    private new InputSystemModel _model;

    private ReactiveProperty<ICharacter> _character = new(EntryPointView.Instance.MainScreenCharacter);

    private KeyboardKeyBindSettings _keyBindSettings = new();

    public KeyboardKeyBindSettings KeyBindSettings { get => _keyBindSettings; set => _keyBindSettings = value; }
    public ICharacter Character { get => _character.GetValue(); set => _character.SetValue(value); }

    public InputSystemController(KeyboardKeyBindSettings keyBindSettings) : base()
    {
        _keyBindSettings.Set(keyBindSettings);
        Init();
    }

    protected async override void Init()
    {
        base.Init();
        var tempTask = AwaitForCharacterInitiationAsync();
        await Task.Run(() => tempTask);
        _model = new(null, _keyBindSettings);
        _character.OnValueChanged.AddListener(_model.SwitchCharacter);
        StartInputTracking();
    }

    public override void Dispose()
    {
        StopInputTracking();
        _character.OnValueChanged.RemoveListener(_model.SwitchCharacter);

        base.Dispose();
        _keyBindSettings.Dispose();
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
        if (GameStateMashine.Current == GameState.KeyBindMenu || GameStateMashine.Current == GameState.MainMenu || GameStateMashine.Current == GameState.SettingsMenu) return;
        foreach (var key in _keyBindSettings.Keys.Values)
        {
            if (Input.GetKeyUp(key)) _model.KeysMethodsPairs[key].Method.Invoke();
        }
    }

    private void TrackUserBaseInput()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            var rigidbody = _character.GetValue().Rigidbody;
            rigidbody.AddForce(new(Input.GetAxis("Horizontal"), 0));
            rigidbody.velocity = new(0, rigidbody.velocity.y);
        }
            
        if (Input.GetKeyUp(KeyCode.Escape) && (GameStateMashine.Current != GameState.SettingsMenu 
            || GameStateMashine.Current != GameState.KeyBindMenu 
            || GameStateMashine.Current != GameState.MainMenu)) 
            GameStateMashine.Instance.ChangeGameState(GameState.SettingsMenu);
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

    private Task AwaitForCharacterInitiationAsync()
    {
        while (AbilitiesAllocator.Instance == null) return Task.Delay(100);
        while (AbilitiesAllocator.CharactersAbilitiesDictionary.Count == 0) return Task.Delay(100);
        return Task.CompletedTask;
    }
}

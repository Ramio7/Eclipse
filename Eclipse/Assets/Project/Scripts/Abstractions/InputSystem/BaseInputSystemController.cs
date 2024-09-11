using UnityEngine;

public class BaseInputSystemController : BaseController
{
    public BaseInputSystemController() : base()
    {
        Init();
    }

    protected new void Init()
    {
        _model = new BaseInputSystemModel();

        EntryPointView.OnUpdate += TrackUserBaseInput;
    }

    public override void Dispose()
    {
        base.Dispose();

        EntryPointView.OnUpdate -= TrackUserBaseInput;
    }

    private void TrackUserBaseInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && (GameStateMashine.Current != GameState.MainMenu))
            GameStateMashine.Instance.ChangeGameState(GameState.MainMenu);
        /*else if (Input.GetKeyUp(KeyCode.Escape) && GameStateMashine.Current == GameState.MainMenu)

#if UNITY_EDITOR
            Debug.Break();
#else
            Application.Quit();
#endif*/

        if (Input.GetKeyUp(KeyCode.LeftAlt) && Input.GetKeyUp(KeyCode.F4))

#if UNITY_EDITOR
            Debug.Break();
#else
            Application.Quit();
#endif

    }

    /*private async void InitCharacter()
    {
        var tempTask = AwaitForCharacterInitiationAsync();
        await Task.Run(() => tempTask);
        var model = _model as BaseInputSystemModel;
        //_character.OnValueChanged.AddListener(model.SwitchCharacter);
    }

    private Task AwaitForCharacterInitiationAsync()
    {
        while (AbilitiesAllocator.Instance == null) return Task.Delay(100);
        while (AbilitiesAllocator.CharactersAbilitiesDictionary.Count == 0) return Task.Delay(100);
        return Task.CompletedTask;
    }

    private void StartInputTracking() => EntryPointView.OnUpdate += TrackUserAbilitiesInput;

    private void StopInputTracking() => EntryPointView.OnUpdate -= TrackUserAbilitiesInput;

    private void TrackUserAbilitiesInput()
    {
        if (GameStateMashine.Current != GameState.Game) return;
        var model = _model as BaseInputSystemModel;
        foreach (var key in _keyBindSettings.AbilityKyes.Values)
        {
            if (Input.GetKeyUp(key)) model.KeysMethodsPairs[key].Method.Invoke();
        }
    }

    private void TrackHorizontalAxisInput()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            var rigidbody = _character.GetValue().Rigidbody;
            rigidbody.AddForce(new(Input.GetAxis("Horizontal"), 0));
            rigidbody.velocity = new(0, rigidbody.velocity.y);
        }
    }*/
}

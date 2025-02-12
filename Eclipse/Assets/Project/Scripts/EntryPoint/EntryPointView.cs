using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class EntryPointView : BaseView, IView
{
    [SerializeField] private EntryPointScriptableObject _entryPointData;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private VolumeProfile _volumeProfile;
    [SerializeField] private MainCharacterView _mainScreenCharacter;

    private CanvasSelector _canvasSelector;
    private GameStateMashine _gameStateMashine;
    private AbilitiesPool _abilitiesPool;

    public AudioMixer AudioMixer { get => _audioMixer; }
    public VolumeProfile VolumeProfile { get => _volumeProfile; }
    public MainCharacterView MainScreenCharacter { get => _mainScreenCharacter; }

    public static event Action OnUpdate;
    public static event Action OnFixedUpdate;
    public static event Action OnGuiUpdate;

    public static EntryPointView Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            _gameStateMashine = new();
            _abilitiesPool = new();
            _canvasSelector = new();

            EntryPointController entryPointController = new(_entryPointData, this);
            UserKeyboardInputController userKeyboardInputController = new();
        }
        else Destroy(this);
    }

    private void Start()
    {
        _canvasSelector.SwitchCanvas(GameState.MainMenu);
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    private void FixedUpdate() 
    {
        OnFixedUpdate?.Invoke();
    }

    private void OnGUI()
    {
        OnGuiUpdate?.Invoke();
    }

    private void OnDestroy()
    {
        _abilitiesPool?.Dispose();
        _gameStateMashine?.Dispose();
        _canvasSelector?.Dispose();

        _abilitiesPool = null;
        _gameStateMashine = null;
        _canvasSelector = null;

        ControllerList.DisposeAllControllers();
        ModelList.DisposeAllModels();
    }
}

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

    private EntryPointController _controller;
    private CanvasSelector _canvasSelector;
    private GameStateMashine _gameStateMashine;
    private AbilitiesAllocator _abilitiesAllocator;
    private BaseInputSystemController _inputSystemController;

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

            _abilitiesAllocator = new();

            _controller = new(_entryPointData, this);
            _inputSystemController = new();

            _gameStateMashine = new();
            _canvasSelector = new();
        }
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
        _abilitiesAllocator.Dispose();
        _gameStateMashine.Dispose();
        _canvasSelector.Dispose();

        _abilitiesAllocator = null;
        _gameStateMashine = null;
        _canvasSelector = null;
        _controller = null;
        _inputSystemController = null;

        ControllerList.DisposeAllControllers();
        ModelList.DisposeAllModels();
    }
}

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

    public AudioMixer AudioMixer { get => _audioMixer; }
    public VolumeProfile VolumeProfile { get => _volumeProfile; }
    public MainCharacterView MainScreenCharacter { get => _mainScreenCharacter; }

    public static event Action OnUpdate;
    public static event Action OnFixedUpdate;
    public static event Action OnGuiUpdate;

    public static EntryPointView Instance;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            _abilitiesAllocator = new();
            AbilitiesAllocator.AddNewCharacter(_mainScreenCharacter);

            _controller = new(_entryPointData, this);

            _gameStateMashine = new();
            _canvasSelector = new();

            _canvasSelector.SwitchCanvas(GameState.MainMenu);
        }
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
        _gameStateMashine.Dispose();
        _canvasSelector.Dispose();

        _gameStateMashine = null;
        _canvasSelector = null;
        _controller = null;

        ControllerList.DisposeAllControllers();
        ModelList.DisposeAllModels();
    }
}

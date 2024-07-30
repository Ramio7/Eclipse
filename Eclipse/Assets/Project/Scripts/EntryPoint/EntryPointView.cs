using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class EntryPointView : MonoBehaviour, IView
{
    [SerializeField] private EntryPointScriptableObject _entryPointData;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private VolumeProfile _volumeProfile;
    [SerializeField] private BaseCharacter _mainScreenCharacter;

    private EntryPointController _controller;
    private CanvasSelector _canvasSelector;
    private GameStateMashine _gameStateMashine;
    private AbilitiesAllocator _abilitiesAllocator;

    public AudioMixer AudioMixer { get => _audioMixer; }
    public VolumeProfile VolumeProfile { get => _volumeProfile; }
    public BaseCharacter MainScreenCharacter { get => _mainScreenCharacter; }

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
            _controller = new(_entryPointData, this);
            _gameStateMashine = new();
            _canvasSelector = new();
            CanvasSelector.Instance.SwitchCanvas(GameState.MainMenu);
            _abilitiesAllocator = new();
            AbilitiesAllocator.AddNewCharacter(_mainScreenCharacter);
        }
    }

    private void Update()
    {
        OnUpdate?.Invoke();

        if (Input.GetKeyUp(KeyCode.Escape))
        {
#if UNITY_EDITOR
            Debug.Break();
#else
            Application.Quit();
#endif
        }
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
        _controller.Dispose();

        _gameStateMashine = null;
        _canvasSelector = null;
        _controller = null;
    }
}

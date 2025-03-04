using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class EntryPointView : BaseView, IView
{
    [SerializeField] private EntryPointScriptableObject _entryPointData;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private VolumeProfile _volumeProfile;
    private static MainCharacterView _mainScreenCharacter;

    private CanvasSelector _canvasSelector;
    private GameStateMashine _gameStateMashine;
    private AbilitiesPool _abilitiesPool;
    private GameTimerFactory _gameTimerFactory;

    public AudioMixer AudioMixer { get => _audioMixer; }
    public VolumeProfile VolumeProfile { get => _volumeProfile; }
    public GameTimerFactory GameTimerFactory { get => _gameTimerFactory; }
    public static MainCharacterView MainScreenCharacter { get => _mainScreenCharacter; }

    public static EntryPointView Instance;

    private void Awake()
    {
        _mainScreenCharacter = FindFirstObjectByType<MainCharacterView>();
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            _gameTimerFactory = new(DateTime.Now);
            _gameStateMashine = new();
            _abilitiesPool = new();
            _canvasSelector = new();

            new EntryPointController(_entryPointData, this);
            new UserKeyboardInputController();

            GameEvents.OnFixedUpdate += GameTimersTick;
            GameEvents.OnFixedUpdate += CheckTimerStatus;
            var newTimer = new GameTimer(30000);
            GameTimerFactory.AddTimer(newTimer);

        }
        else Destroy(this);
    }

    private void Start()
    {
        _canvasSelector.SwitchCanvas(GameState.MainMenu);
    }

    private void Update()
    {
        GameEvents.OnUpdate?.Invoke();
    }

    private void FixedUpdate()
    {
        GameEvents.OnFixedUpdate?.Invoke();
    }

    private void OnGUI()
    {
        GameEvents.OnGuiUpdate?.Invoke();
    }

    private void LateUpdate()
    {
        GameEvents.OnLateUpdate?.Invoke();
    }

    private void OnDestroy()
    {
        _abilitiesPool?.Dispose();
        _gameStateMashine?.Dispose();
        _canvasSelector?.Dispose();
        _gameTimerFactory.Dispose();

        _abilitiesPool = null;
        _gameStateMashine = null;
        _canvasSelector = null;

        GameEvents.OnFixedUpdate -= GameTimersTick;
        GameEvents.OnFixedUpdate -= CheckTimerStatus;

        ControllerList.DisposeAllControllers();
        ModelList.DisposeAllModels();
    }

    private void GameTimersTick()
    {
        if (_gameTimerFactory.TimerList.IsEmpty) return;
        else
        {
            int timerTotal = _gameTimerFactory.TimerList.Length;
            for (int i = 0; i < timerTotal; i++)
            {
                var currentTimer = _gameTimerFactory.TimerList[i];
                _gameTimerFactory.Execute(i);
            }
        }
    }

    private void CheckTimerStatus()
    {
        if (_gameTimerFactory.TimerList.IsEmpty) return;
        else
        {
            int timerTotal = _gameTimerFactory.TimerList.Length;
            for (int i = 0; i < timerTotal; i++)
            {
                var currentTimer = _gameTimerFactory.TimerList[i];

                if (currentTimer.IsDisposed[0])
                {
                    return;
                }

                switch (currentTimer.IsExpired[0])
                {
                    case true:
                        GameEvents.OnTimerExpired?.Invoke();
                        break;
                    case false:
                        break;
                }
            }

        }
    }
}

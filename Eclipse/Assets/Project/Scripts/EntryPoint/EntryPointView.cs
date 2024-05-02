using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class EntryPointView : MonoBehaviour, IView
{
    [SerializeField] private EntryPointScriptableObject _entryPointData;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private VolumeProfile _volumeProfile;

    private EntryPointController _controller;

    public AudioMixer AudioMixer { get => _audioMixer; }
    public VolumeProfile VolumeProfile { get => _volumeProfile; }

    public static event Action OnUpdate;
    public static event Action OnFixedUpdate;

    public static EntryPointView Instance;

    private void OnEnable()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        _controller = new(this, _entryPointData);
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

    private void OnDestroy()
    {
        DisposeController();
    }

    private void DisposeController()
    {
        _controller.Dispose();
        _controller = null;
    }
}

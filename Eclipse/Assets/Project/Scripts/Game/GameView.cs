using UnityEngine;

public class GameView : BaseView
{
    [SerializeField] private GameScriptableObject _gameScriptableObject;

    private GameController _controller;

    public static GameView Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            _controller = new(_gameScriptableObject, this);
        }
        else if (Instance.GameObject != this) Destroy(this);
    }

    public void OnDestroy()
    {
        _controller =null;
    }
}

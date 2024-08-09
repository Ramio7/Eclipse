using UnityEngine;

public class GameView : BaseView
{
    [SerializeField] private GameScriptableObject _gameScriptableObject;

    private GameController _controller;

    public static GameView Instance;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            _controller = new(_gameScriptableObject, this);
        }
    }

    public void OnDestroy()
    {
        _controller =null;
    }
}

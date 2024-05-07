using UnityEngine;

public class GameView : MonoBehaviour, IView
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

            _controller = new(this, _gameScriptableObject);
        }
    }

    public void OnDestroy()
    {
        _controller.Dispose();

        _controller = null;
    }
}

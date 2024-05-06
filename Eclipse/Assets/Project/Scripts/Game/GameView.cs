using UnityEngine;

public class GameView : MonoBehaviour, IView
{
    [SerializeField] private GameScriptableObject _gameScriptableObject;

    private GameController _controller;

    public Canvas GameLoaderCanvas {  get; private set; }

    private void OnEnable()
    {
        DontDestroyOnLoad(this);

        _controller = new(this, _gameScriptableObject);
    }

    public void OnDestroy()
    {
        _controller.Dispose();

        _controller = null;
    }
}

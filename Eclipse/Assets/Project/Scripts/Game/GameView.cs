using UnityEngine;

public class GameView : BaseView
{
    [SerializeField] private GameScriptableObject _gameScriptableObject;
    [SerializeField] private LevelView _levelView;

    private GameController _controller;

    public static GameView Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            _controller = new(_gameScriptableObject, this);

            GameStateMashine.Instance.ChangeGameState(GameState.Game);

            var character = EntryPointView.Instance.MainScreenCharacter;
            var characterTransform = character.GameObject.transform;
            characterTransform.SetPositionAndRotation(_levelView.StartingPoint.position, characterTransform.rotation);
        }
    }

    public void OnDestroy()
    {
        _controller =null;

        Instance = null;
    }
}

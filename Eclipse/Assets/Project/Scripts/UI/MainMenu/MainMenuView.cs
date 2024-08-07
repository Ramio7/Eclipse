using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : BaseUIView, IView
{
    [SerializeField] private MainMenuScriptableObject _mainMenuData;

    [Header("Main menu buttons")] 
    #region Main menu buttons
    [SerializeField] private Button _continueGameButton;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitGameButton;
    #endregion

    private MainMenuController _controller;

    #region Properties
    public Button ContinueGameButton { get => _continueGameButton; }
    public Button StartGameButton { get => _startGameButton; }
    public Button SettingsButton { get => _settingsButton; }
    public Button ExitGameButton { get => _exitGameButton; }
    #endregion

    public static MainMenuView Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);

            _controller = new(_mainMenuData, this);

            CanvasSelector.AddCanvas(GameState.MainMenu, this);

            SceneManager.sceneLoaded += SetButtonInGame;
        }
    }    

    private void OnDestroy()
    {
        Instance = null;

        _controller.Dispose();

        _controller = null;
    }

    private void SetButtonInGame(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == (int)GameScens.Game) SetContinueGameButtonActive();
        else SetStartGameButtonActive();
    }

    private void SetStartGameButtonActive() => SwitchActiveButton(StartGameButton, ContinueGameButton);
    private void SetContinueGameButtonActive() => SwitchActiveButton(ContinueGameButton, StartGameButton);
    private void SwitchActiveButton(Button buttonToActivate, Button buttonToDisable)
    {
        buttonToActivate.gameObject.SetActive(true);
        buttonToDisable.gameObject.SetActive(false);
    }
}

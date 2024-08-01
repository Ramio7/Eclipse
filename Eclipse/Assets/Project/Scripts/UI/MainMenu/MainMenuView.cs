using UnityEngine;
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
        }
    }

    private void OnDestroy()
    {
        Instance = null;

        _controller.Dispose();

        _controller = null;
    }
}

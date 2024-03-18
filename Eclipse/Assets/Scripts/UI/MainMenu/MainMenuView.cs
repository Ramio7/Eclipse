using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, IView
{
    [SerializeField] private MainMenuScriptableObject _mainMenuData;

    [Header("Main menu buttons")] 
    #region Main menu buttons
    [SerializeField] private Button _continueGameButton;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitGameButton;
    #endregion

    [Header("Settings menu buttons")]
    #region Settings menu buttons
    [SerializeField] private Button _backToMainMenuButton;
    #endregion

    [Header("Canvas")]
    #region Canvas
    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _settingsCanvas;
    #endregion

    private MainMenuController _controller;

    public List<Action> Actions => throw new NotImplementedException();

    public Button ContinueGameButton { get => _continueGameButton; }
    public Button StartGameButton { get => _startGameButton; }
    public Button SettingsButton { get => _settingsButton; }
    public Button ExitGameButton { get => _exitGameButton; }
    public Canvas MainMenuCanvas { get => _mainMenuCanvas; }
    public Canvas SettingsCanvas { get => _settingsCanvas; }
    public Button BackToMainMenuButton { get => _backToMainMenuButton; }

    private void OnEnable()
    {
        _controller = new(this, _mainMenuData);
    }

    private void OnDestroy()
    {
        _controller.Dispose();

        _controller = null;
    }
}

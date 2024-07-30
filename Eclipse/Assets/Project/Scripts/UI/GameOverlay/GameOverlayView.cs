using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverlayView : MonoBehaviour, IUIView
{
    [SerializeField] private GameOverlayScriptableObject _gameOverlayDefaults;
    [SerializeField] private Canvas _canvas;

    #region CharacterPanel

    [SerializeField] private Image _characterIcon;
    [SerializeField] private Text _characterName;
    [SerializeField] private Slider _hitPoints;
    [SerializeField] private Slider _manaPoints;

    #endregion

    #region AbilitiesPanel

    [SerializeField] private Button _firstAbilityButton;
    [SerializeField] private Button _secondAbilityButton;
    [SerializeField] private Button _thirdAbilityButton;
    [SerializeField] private Button _fourthAbilityButton;

    #endregion

    #region InventoryPanel

    [SerializeField] private Button _firstPocket;
    [SerializeField] private Button _secondPocket;
    [SerializeField] private Button _thirdPocket;
    [SerializeField] private Button _fourthPocket;
    [SerializeField] private Button _fifthPocket;
    [SerializeField] private Button _sixthPocket;
    [SerializeField] private Button _seventhPocket;
    [SerializeField] private Button _eightPocket;

    #endregion

    #region QuestsPanel

    [SerializeField] private Canvas _firstQuestPanel;
    [SerializeField] private Canvas _secondQuestPanel;
    [SerializeField] private Canvas _thirdQuestPanel;
    [SerializeField] private Canvas _fourthQuestPanel;
    [SerializeField] private Canvas _fifthQuestPanel;
    [SerializeField] private Canvas _sixthQuestPanel;
    [SerializeField] private Canvas _seventhQuestPanel;

    [SerializeField] private TMP_Text _firstQuestInfo;
    [SerializeField] private TMP_Text _secondQuestInfo;
    [SerializeField] private TMP_Text _thirdQuestInfo;
    [SerializeField] private TMP_Text _fourthQuestInfo;
    [SerializeField] private TMP_Text _fifthQuestInfo;
    [SerializeField] private TMP_Text _sixthQuestInfo;
    [SerializeField] private TMP_Text _seventhQuestInfo;

    #endregion

    private GameOverlayController _controller;

    public Canvas Canvas { get => _canvas; private set => _canvas = value; }

    private void OnEnable()
    {
        _controller = new(_gameOverlayDefaults, this);
    }
}

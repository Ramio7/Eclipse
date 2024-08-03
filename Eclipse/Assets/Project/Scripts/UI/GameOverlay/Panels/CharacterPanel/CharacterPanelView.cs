using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelView : BaseUIView, ICharacterPanelView
{
    [SerializeField] private Image _characterIcon;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Slider _mpSlider;
    [SerializeField] private TMP_Text _characterName;

    public Image CharacterIcon { get => _characterIcon; private set => _characterIcon = value; }
    public Slider HPSlider { get => _hpSlider; private set => _hpSlider = value; }
    public Slider MPSlider { get => _mpSlider; private set => _mpSlider = value; }
    public TMP_Text CharacterName { get => _characterName; private set => _characterName = value; }
}

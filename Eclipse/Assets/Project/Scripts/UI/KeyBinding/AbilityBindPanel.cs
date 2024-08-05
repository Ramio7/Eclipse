using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBindPanel : BaseUIView, IAbilityBindPanel
{
    private Button _button;
    private TMP_Text _text;
    private KeyCode _abilityKey;

    public Button AbilityButton { get => _button; private set => _button = value; }
    public TMP_Text AbilityName { get => _text; set => _text = value; }
    public KeyCode AbilityKey { get => _abilityKey; set => _abilityKey = value; }

    private void Start()
    {
        _button = GetComponent<Button>();
        _text = GetComponent<TMP_Text>();
    }
}

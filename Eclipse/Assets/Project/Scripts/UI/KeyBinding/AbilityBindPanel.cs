using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBindPanel : BaseUIView, IAbilityBindPanel
{
    protected Button _abilityButton;
    protected TMP_Text _abilityName;
    protected KeyCode _abilityKey;
    protected IAbility _ability;

    public Button AbilityButton { get => _abilityButton; private set => _abilityButton = value; }
    public TMP_Text AbilityName { get => _abilityName; set => _abilityName = value; }
    public KeyCode AbilityKey { get => _abilityKey; set => _abilityKey = value; }
    public IAbility Ability { get => _ability; set => _ability = value; }

    private void Start()
    {
        _abilityButton = GetComponent<Button>();
        _abilityName = GetComponent<TMP_Text>();
    }
}

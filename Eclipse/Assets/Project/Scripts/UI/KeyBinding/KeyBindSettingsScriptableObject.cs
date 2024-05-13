using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(KeyBindSettingsScriptableObject), fileName = nameof(KeyBindSettingsScriptableObject))]
public class KeyBindSettingsScriptableObject : BaseScriptableObject
{
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private KeyCode _shiftKey;
    [SerializeField] private KeyCode _crouchKey;
    [SerializeField] private KeyCode _slideKey;
    [SerializeField] private KeyCode _firstAbilityKey;
    [SerializeField] private KeyCode _secondAbilityKey;
    [SerializeField] private KeyCode _thirdAbilityKey;
    [SerializeField] private KeyCode _fourthAbilityKey;

    public KeyCode JumpKey { get => _jumpKey; }
    public KeyCode ShiftKey { get => _shiftKey; }
    public KeyCode CrouchKey { get => _crouchKey; }
    public KeyCode SlideKey { get => _slideKey; }
    public KeyCode FirstAbilityKey { get => _firstAbilityKey; }
    public KeyCode SecondAbilityKey { get => _secondAbilityKey; }
    public KeyCode ThirdAbilityKey { get => _thirdAbilityKey; }
    public KeyCode FourthAbilityKey { get => _fourthAbilityKey; }
}

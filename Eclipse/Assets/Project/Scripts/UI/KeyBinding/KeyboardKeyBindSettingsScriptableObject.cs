using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(KeyboardKeyBindSettingsScriptableObject), fileName = nameof(KeyboardKeyBindSettingsScriptableObject))]
public class KeyboardKeyBindSettingsScriptableObject : BaseScriptableObject
{
    [SerializeField] private AbilityStruct _jumpAbility;
    [SerializeField] private KeyCode[] _jumpKey;
    [SerializeField] private KeyCode[] _shiftKey;
    [SerializeField] private KeyCode[] _crouchKey;
    [SerializeField] private KeyCode[] _slideKey;
    [SerializeField] private KeyCode[] _firstAbilityKey;
    [SerializeField] private KeyCode[] _secondAbilityKey;
    [SerializeField] private KeyCode[] _thirdAbilityKey;
    [SerializeField] private KeyCode[] _fourthAbilityKey;
    [SerializeField] private KeyCode[] _useTalkKey;
    [SerializeField] private KeyCode[] _moveAbilityKey;

    public KeyCode[] JumpKey { get => _jumpKey; }
    public KeyCode[] ShiftKey { get => _shiftKey; }
    public KeyCode[] CrouchKey { get => _crouchKey; }
    public KeyCode[] SlideKey { get => _slideKey; }
    public KeyCode[] FirstAbilityKey { get => _firstAbilityKey; }
    public KeyCode[] SecondAbilityKey { get => _secondAbilityKey; }
    public KeyCode[] ThirdAbilityKey { get => _thirdAbilityKey; }
    public KeyCode[] FourthAbilityKey { get => _fourthAbilityKey; }
    public KeyCode[] UseTalkKey { get => _useTalkKey; }
    public KeyCode[] MoveAbilityKey { get => _moveAbilityKey; }
}

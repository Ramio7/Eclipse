public class MainCharacterView : BaseCharacter, IMortalCharacter
{
    private int _health = 0;
    public int Health { get => _health; private set => _health = value; }

    private void Awake()
    {
        JumpAbility jumpAbility = new();
        CrouchAbility crouchAbility = new();

        _abilities.Add(jumpAbility);
        _abilities.Add(crouchAbility);
    }
}

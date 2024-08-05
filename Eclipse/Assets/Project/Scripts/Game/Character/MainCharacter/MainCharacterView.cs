public class MainCharacterView : BaseCharacter, IMortalCharacter
{
    private int _health = 0;
    public int Health { get => _health; private set => _health = value; }

    private void Awake()
    {
        JumpAbility jumpAbility = new(this);
        CrouchAbility crouchAbility = new(this);

        _abilities.Add(jumpAbility);
        _abilities.Add(crouchAbility);
    }
}

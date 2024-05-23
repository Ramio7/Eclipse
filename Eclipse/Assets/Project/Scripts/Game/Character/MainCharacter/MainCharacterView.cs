using System.Collections.Generic;

public class MainCharacterView : BaseCharacter
{
    private void Awake()
    {
        JumpAbility jumpAbility = new();
        CrouchAbility crouchAbility = new();
        _abilities = new List<IAbility>() { jumpAbility, crouchAbility };
    }
}

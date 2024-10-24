using System.Collections.Generic;
using UnityEngine;

public class UserKeyboardInputModel : BaseInputSystemModel
{
    public List<IAbility> TakeAbilitiesFromAllocator(KeyCode keyCode) => AbilitiesAllocator.GetAbilitiesContainingKeys(AbilitiesAllocator.MainCharacter, keyCode);
}

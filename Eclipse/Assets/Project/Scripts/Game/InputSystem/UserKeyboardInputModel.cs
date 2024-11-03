using UnityEngine;

public class UserKeyboardInputModel : BaseInputSystemModel
{
    public IAbility TakeAbilityFromAllocator(KeyCode previousKey, KeyCode currentKey)
        => AbilitiesAllocator.GetAbilityContainingKey(AbilitiesAllocator.MainCharacter, previousKey, currentKey);

    public void PushAbilityToCash(IAbility ability)
    {
        ability.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
        AbilityCash.AddAbilityToCash(ability);
    }
}

using UnityEngine;

public class UserKeyboardInputModel : BaseInputSystemModel
{
    public IAbility TakeAbilityFromPull(KeyCode previousKey, KeyCode currentKey)
        => AbilitiesPool.GetAbilityContainingKeys(AbilitiesPool.MainCharacter, previousKey, currentKey);

    public void PushAbilityToCash(IAbility ability)
    {
        ability.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
        AbilityCash.AddAbilityToCash(ability);
    }
}

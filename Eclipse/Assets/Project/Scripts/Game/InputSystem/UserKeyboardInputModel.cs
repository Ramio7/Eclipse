using UnityEngine;

public class UserKeyboardInputModel : BaseInputSystemModel
{
    public UserKeyboardInputModel()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }

    public IAbility TakeAbilityFromPull(KeyCode currentKey)
        => AbilitiesPool.GetAbilityByKey(AbilitiesPool.MainCharacter, currentKey);

    public void PushAbilityToCash(IAbility ability)
    {
        ability.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
        AbilityCash.AddAbilityToCash(ability);
    }

    public void InvokeMoveAbility()
    {
        if (HorizontalAxis != 0)
        {
            var moveAbility = AbilitiesPool.GetMainCharacterAbility<MoveAbility>();
            moveAbility.SetAbilityInvokeParameters(HorizontalAxis, VerticalAxis);
            AbilityCash.AddAbilityToCash(moveAbility);
        }
    }
}

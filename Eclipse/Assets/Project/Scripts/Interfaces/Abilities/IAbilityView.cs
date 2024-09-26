public interface IAbilityView
{
    BaseAbilityScriptableObject AbilityDefaults { get; set; }
    IAbility Ability {  get; }
}

using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseMainCharacterAbilityView : MonoBehaviour, IAbilityView
{
    [SerializeField] protected BaseAbilityScriptableObject abilityDefaults;
    protected IAbilityBindPanel abilityBindPanel;
    protected IAbility ability;

    public BaseAbilityScriptableObject AbilityDefaults { get => abilityDefaults; set => abilityDefaults = value; }
    public IAbility Ability { get => ability; protected set => ability = value; }

    protected virtual void Init()
    {
        Task.Run(() => AwaitCharacterInitializationAsync());
        abilityBindPanel = GetComponent<IAbilityBindPanel>();
        abilityBindPanel.AbilityKey = abilityDefaults.KeyCode;
    }

    private Task AwaitCharacterInitializationAsync()
    {
        if (AbilitiesPool.MainCharacter == null) Task.Delay(100);
        return Task.CompletedTask; 
    }
}

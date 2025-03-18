using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseMainCharacterAbilityView : MonoBehaviour, IAbilityView
{
    [SerializeField] protected BaseAbilityScriptableObject abilityDefaults;
    protected IAbilityBindPanel abilityBindPanel;
    protected IAbility ability;

    public BaseAbilityScriptableObject AbilityDefaults { get => abilityDefaults; set => abilityDefaults = value; }
    public IAbility Ability { get => ability; protected set => ability = value; }

    protected virtual void InitAsync()
    {
        abilityBindPanel = GetComponent<IAbilityBindPanel>();
        abilityBindPanel.AbilityKey = abilityDefaults.KeyCode;
    }

    protected Task AwaitAbilityInitiation<IAbility>()
    {
        while (PlayerAbilitiesPool.GetMainCharacterAbility<IAbility>() == null)
            return Task.Delay(100);
        return Task.CompletedTask;
    }

    protected virtual void OnDestroy()
    {
        abilityBindPanel = null;
        ability = null;
        abilityDefaults = null;
    }
}

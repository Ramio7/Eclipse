using UnityEngine;

public static class AbilityCash
{
    public static int CashCapacity = 12;
    public static IAbility ActiveAbility;

    private static IAbility[] AbilitiesCash = new IAbility[CashCapacity];

    public static void AddAbilityToCash(IAbility ability)
    {
        var freeIndex = ArrayUtility<IAbility>.GetFreeIndex(AbilitiesCash);
        AbilitiesCash[freeIndex] = ability;
    }

    public static void InvokeAbilities()
    {
        if (ArrayUtility<IAbility>.ArrayIsNull(AbilitiesCash)) return;

        for (int i = 0; i < AbilitiesCash.Length; i++) //Make abilities work well
        {
            if (AbilitiesCash[i] == null) continue;

            ActiveAbility?.Cancel();
            ActiveAbility = AbilitiesCash[i];
            AbilitiesCash[i] = null;
            ActiveAbility.Invoke();
            Debug.Log($"{ActiveAbility} is invoked");
            continue;
        }

        ArrayUtility<IAbility>.ClearArray(AbilitiesCash);
    }
}

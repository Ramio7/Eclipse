public static class AbilityCash
{
    private static IAbility[] _abilitiesCash = new IAbility[12];

    public static void AddAbilityToCash(IAbility ability)
    {
        if (ArrayUtility<IAbility>.ArrayIsNull(_abilitiesCash))
        {
            InvokeAbilities();
            return;
        }

        var freeIndex = ArrayUtility<IAbility>.GetFreeIndex(_abilitiesCash);
        _abilitiesCash[freeIndex] = ability;
    }

    public static void InvokeAbilities()
    {
        for (int i = 0; i < _abilitiesCash.Length; i++)
        {
            if (i == 0) _abilitiesCash[i].Invoke();
            else
            {
                if (_abilitiesCash[i] == _abilitiesCash[i - 1]) continue;
                else
                {
                    _abilitiesCash[i - 1].Cancel();
                    _abilitiesCash[i].Invoke();
                }
            }
        }
    }
}

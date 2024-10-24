public static class AbilityCash
{
    private static IAbility[] _abilitiesCash = new IAbility[12];
    private static IAbility _activeAbility;

    public static void AddAbilityToCash(IAbility ability)
    {
        if (ArrayUtility<IAbility>.ArrayIsFull(_abilitiesCash))
        {
            InvokeAbilities();
            ArrayUtility<IAbility>.ClearArray(_abilitiesCash);
            return;
        }

        var freeIndex = ArrayUtility<IAbility>.GetFreeIndex(_abilitiesCash);
        _abilitiesCash[freeIndex] = ability;
    }

    public static void InvokeAbilities()
    {
        for (int i = 0; i < _abilitiesCash.Length; i++)
        {
            if (i == 0 && _activeAbility != _abilitiesCash[i])
            {
                _activeAbility = _abilitiesCash[i];
                _abilitiesCash[i].Invoke();
                ArrayUtility<IAbility>.ClearArray(_abilitiesCash);
                return;
            }
            else
            {
                if (_abilitiesCash[i] == _activeAbility) continue;
                else
                {
                    _activeAbility.Cancel();
                    _activeAbility = _abilitiesCash[i];
                    _abilitiesCash[i].Invoke();
                    ArrayUtility<IAbility>.ClearArray(_abilitiesCash);
                    return;
                }
            }
        }
    }
}

using System.Collections.Generic;

public static class PlayerAbilityQueue
{
    public static IAbility InvokedAbility;
    private static List<IAbility> QueuedAbilities = new();

    public static void AddAbilityToQueue(IAbility ability) => QueuedAbilities.Add(ability);

    public static void InvokeAbility()
    {
        foreach (var ability in QueuedAbilities)
        {
            if (ability == null) continue;

            if (InvokedAbility == null)
            {
                InvokedAbility = ability;
                InvokedAbility.Invoke();
                QueuedAbilities.Clear();
                return;
            }

            if (!InvokedAbility.IsInvoking)
            {
                InvokeQueuedAbility(ability);
                QueuedAbilities.Clear();
                return;
            }
            else
            {
                if (ability.GetType() == InvokedAbility.GetType()) continue;

                InvokedAbility.CancellationTokenSource.Cancel();
                InvokeQueuedAbility(ability);
                QueuedAbilities.Clear();
                return;
            }
        }
    }

    private static void InvokeQueuedAbility(IAbility ability)
    {
        ability.Invoke();
        InvokedAbility = ability;
        QueuedAbilities.Remove(ability);
    }
}

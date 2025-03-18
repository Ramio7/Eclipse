using System.Threading;

public abstract class BaseAbility : IAbility, IAxesControlledAbility
{
    protected int abilityId;
    protected bool isInvoking;
    protected ICharacter character;
    protected CancellationTokenSource cancellationTokenSource;
    protected float horizontalAxis;
    protected float verticalAxis;
    protected int abilityCooldown;

    public int AbilityId { get => abilityId; set => abilityId = value; }
    public bool IsInvoking { get => isInvoking; set => isInvoking = value; }
    public float HorizontalAxis { get => horizontalAxis; set => horizontalAxis = value; }
    public float VerticalAxis { get => verticalAxis; set => verticalAxis = value; }
    public CancellationTokenSource CancellationTokenSource { get => cancellationTokenSource; set => cancellationTokenSource = value; }
    public int AbilityCooldown { get => abilityCooldown; private set => abilityCooldown = value; }

    public BaseAbility(ICharacter character)
    {
        this.character = character;
        GameEvents.OnAbilityStoped += ReinitCancellationTokenSource;
    }

    protected virtual void Init()
    {
        cancellationTokenSource = new CancellationTokenSource();

        horizontalAxis = 0;
        verticalAxis = 0;
    }

    public virtual void Dispose()
    {
        cancellationTokenSource.Dispose();
        GameEvents.OnAbilityStoped -= ReinitCancellationTokenSource;
    }

    public virtual void SetAbilityInvokeParameters(float horizontalAxisValue, float verticalAxisValue)
    {
        horizontalAxis = horizontalAxisValue;
        verticalAxis = verticalAxisValue;
    }

    public void Invoke() => Method();

    public virtual void Cancel()
    {
        ReinitCancellationTokenSource(this);
    }

    public void ReinitCancellationTokenSource(IAbility ability)
    {
        if (ability != this) return;
        cancellationTokenSource.Dispose();
        cancellationTokenSource = new();
        IsInvoking = false;
    }

    protected virtual void Method()
    {
        if (cancellationTokenSource.IsCancellationRequested)
        {
            IsInvoking = false;
            Cancel();
            return;
        }
        isInvoking = true;
    }
}

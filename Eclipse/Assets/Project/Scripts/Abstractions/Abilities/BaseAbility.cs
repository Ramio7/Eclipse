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
    }

    public virtual void SetAbilityInvokeParameters(float horizontalAxisValue, float verticalAxisValue)
    {
        horizontalAxis = horizontalAxisValue;
        verticalAxis = verticalAxisValue;
    }

    public void Invoke() => Method();

    public virtual void Cancel()
    {
        IsInvoking = false;
        cancellationTokenSource.Cancel();
        ReinitCancellationTokenSource();
    }

    public void ReinitCancellationTokenSource()
    {
        cancellationTokenSource.Dispose();
        cancellationTokenSource = new();
    }

    protected virtual void Method()
    {
    }

}

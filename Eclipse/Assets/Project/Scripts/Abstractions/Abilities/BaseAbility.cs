using System.Threading;

public abstract class BaseAbility : IAbility, IAxesControlledAbility
{
    protected int abilityId;
    protected ICharacter character;
    protected CancellationTokenSource cancellationTokenSource;
    protected CancellationToken cancellationToken;
    protected float horizontalAxis;
    protected float verticalAxis;

    public CancellationToken CancellationToken { get => cancellationToken; private set => cancellationToken = value; }
    public int AbilityId { get => abilityId; set => abilityId = value; }
    public float HorizontalAxis { get => horizontalAxis; set => horizontalAxis = value; }
    public float VerticalAxis { get => verticalAxis; set => verticalAxis = value; }

    public BaseAbility(ICharacter character)
    {
        this.character = character;
    }

    protected virtual void Init()
    {
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;

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

    public virtual void Cancel() => cancellationTokenSource.Cancel();

    protected virtual void Method()
    {
        if (cancellationToken.IsCancellationRequested) return;
    }
}

using System.Threading;

public abstract class BaseAbility : IAbility
{
    protected ICharacter character;
    protected CancellationTokenSource cancellationTokenSource;
    protected CancellationToken cancellationToken;
    protected float horizontalAxis;
    protected float verticalAxis;

    public CancellationToken CancellationToken { get => cancellationToken; private set => cancellationToken = value; }

    public BaseAbility(ICharacter character)
    {
        this.character = character;
    }

    public virtual void Init()
    {
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
    }

    public void SetAbilityInvokeParameters(float horizontalAxisValue, float verticalAxisValue)
    {
        horizontalAxis = horizontalAxisValue;
        verticalAxis = verticalAxisValue;
    }

    public virtual void Invoke() => Method();

    public virtual void Cancel() => cancellationTokenSource.Cancel();

    protected virtual void Method()
    {
        if (cancellationToken.IsCancellationRequested) return;
    }

    public virtual void Dispose()
    {
    }
}

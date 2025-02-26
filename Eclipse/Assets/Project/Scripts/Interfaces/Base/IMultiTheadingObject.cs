using System.Threading;

public interface IMultiTheadingObject
{
    CancellationTokenSource CancellationTokenSource { get; }
}

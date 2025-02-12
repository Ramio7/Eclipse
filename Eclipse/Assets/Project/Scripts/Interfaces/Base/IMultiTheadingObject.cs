using System.Threading;

public interface IMultiTheadingObject
{
    CancellationToken CancellationToken { get; }
}

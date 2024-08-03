using System.Collections.Generic;

public interface IMonoobjectsPanelView<T> : IUIView
{
    List<T> Objects { get; }
}

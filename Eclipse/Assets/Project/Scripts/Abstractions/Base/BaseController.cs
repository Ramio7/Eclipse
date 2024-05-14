using UnityEngine;

public abstract class BaseController : IController
{
    protected IView _view;
    protected IModel _model;

    public BaseController(IView view)
    {
        _view = view;
    }

    public abstract void Init();

    protected void InstantiateChildObject(GameObject childObject) => Object.Instantiate(childObject);

    public abstract void Dispose();
}

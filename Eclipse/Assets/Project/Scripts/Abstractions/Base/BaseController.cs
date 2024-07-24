using UnityEngine;

public abstract class BaseController : IController
{
    protected IView _view;
    protected IModel _model;

    public BaseController(IView view)
    {
        _view = view;
    }

    public virtual void Init() => ControllerList.RegisterController(this);

    public abstract void Dispose();

    protected void InstantiateChildObject(GameObject childObject) => Object.Instantiate(childObject);
}

using UnityEngine;

public abstract class BaseController : IController
{
    protected IModel _model;

    public BaseController()
    {
    }

    public virtual void Init() => ControllerList.RegisterController(this);

    public abstract void Dispose();

    protected void InstantiateChildObject(GameObject childObject) => Object.Instantiate(childObject);
}

using UnityEngine;

public abstract class BaseController : IController
{
    protected IModel _model;

    public BaseController()
    {
    }

    public virtual void Init() => ControllerList.RegisterController(this);

    public virtual void Dispose()
    {
        _model?.Dispose();
        _model = null;
    }

    protected void InstantiateChildObject(GameObject childObject) => Object.Instantiate(childObject);
    protected void InstantiateChildObject(GameObject childObject, GameObject parent) => Object.Instantiate(childObject, parent.transform);
}

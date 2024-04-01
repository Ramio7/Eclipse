using UnityEngine;

public class BaseController : IController
{
    protected IView _view;
    protected IModel _model;

    public BaseController(IView view)
    {
        _model = new BaseModel();
        _view = view;
    }

    public virtual void Init()
    {
        _model.Init();
    }

    protected void InstantiateChildObject(GameObject childObject) => Object.Instantiate(childObject);

    public virtual void Dispose()
    {
        _model.Dispose();

        _model = null;
        _view = null;
    }
}

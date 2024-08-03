using System;
using System.Collections.Generic;

public static class ControllerList
{
    private static List<IController> _controllers = new();

    public static void RegisterController(IController controller) => _controllers.Add(controller);

    public static void FindController<T>(out T controller)
    {
        var controllerType = typeof(T);
        controller = (T)_controllers.Find(matchingController => matchingController.GetType() == controllerType);
        if (controller != null) return;
        else throw new Exception("Controller type not found");
    }

    public static void DisposeAllControllers()
    {
        foreach (var controller in _controllers) controller.Dispose();
        _controllers.Clear();
    }
}

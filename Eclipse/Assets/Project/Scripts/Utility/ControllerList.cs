using System.Collections.Generic;

public static class ControllerList
{
    private static List<IController> _controllers = new();

    public static void RegisterController(IController controller) => _controllers.Add(controller);

    public static IController FindController(IController controller) => _controllers.Find(matchingController => matchingController.GetType().Name == controller.GetType().Name);

    public static void DisposeAllControllers()
    {
        foreach (var controller in _controllers) controller.Dispose();
        _controllers.Clear();
    }
}

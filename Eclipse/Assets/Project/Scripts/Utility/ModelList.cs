using System.Collections.Generic;

public static class ModelList
{
    private static List<IModel> _models = new();

    public static void RegisterController(IModel controller) => _models.Add(controller);

    public static IModel FindController(IModel model) => _models.Find(matchingModel => matchingModel.GetType().Name == model.GetType().Name);

    public static void DisposeAllControllers()
    {
        foreach (var model in _models) model.Dispose();
        _models.Clear();
    }
}

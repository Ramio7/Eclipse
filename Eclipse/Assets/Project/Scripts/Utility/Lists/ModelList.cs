using System;
using System.Collections.Generic;

public static class ModelList
{
    private static List<IModel> _models = new();

    public static void RegisterModel(IModel model) => _models.Add(model);

    public static void FindModel<T>(out T model)
    {
        var modelType = typeof(T);
        model = (T)_models.Find(matchingModel => matchingModel.GetType() == modelType);
        if (model != null) return;
        else throw new Exception("Model type not found");
    }

    public static void DisposeAllModels()
    {
        foreach (var model in _models) model?.Dispose();
        _models.Clear();
    }
}

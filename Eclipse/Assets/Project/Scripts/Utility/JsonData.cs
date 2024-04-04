using UnityEngine;
using System.IO;

public static class JsonData<T>
{
    public static void Save(T data, string path = null)
    {
        File.WriteAllText(path, JsonUtility.ToJson(data) /*, Crypto.CryptoXOR(str)*/);
    }

    public static T Load(string path = null)
    {
        var str = File.ReadAllText(path);
        if (str == string.Empty) return default;
        return JsonUtility.FromJson<T>(str /*Crypto.CryptoXOR(str)*/);
    }
}
using UnityEngine;
using System.IO;

public class JsonData<T> : IData<T>
{
    public void Save(T data, string path = null)
    {
        var str = JsonUtility.ToJson(data);
        File.WriteAllText(path, Crypto.CryptoXOR(str));
    }
    public T Load(string path = null)
    {
        var str = File.ReadAllText(path);
        if (str == string.Empty) return default;
        return JsonUtility.FromJson<T>(Crypto.CryptoXOR(str));
    }
}
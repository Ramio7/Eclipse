using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonDictionaryData<Dictionary, T, U> where Dictionary : Dictionary<T, U>
{
    public static void Save(Dictionary<T, U> dic, string path)
    {
        var str = JsonUtility.ToJson(dic);
        File.WriteAllText(path, str /*, Crypto.CryptoXOR(str)*/);
    }

    public static Dictionary<T, U> Load(string path = null)
    {
        var str = File.ReadAllText(path);
        if (str == string.Empty) return default;
        return JsonUtility.FromJson<Dictionary<T, U>>(str /*Crypto.CryptoXOR(str)*/) as Dictionary;
    }
}

using System.IO;
using Newtonsoft.Json;

public static class JsonData<T>
{
    public static void Save(T data, string path = null)
    {
        var str = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, Crypto.CryptoXOR(str));
    }

    public static T Load(string path = null)
    {
        var str = File.ReadAllText(path);
        if (str == string.Empty) return default;
        return JsonConvert.DeserializeObject<T>(Crypto.CryptoXOR(str));
    }
}
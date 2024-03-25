using System.Collections.Generic;
using System.Reflection;

public interface IScriptableObject
{
    List<FieldInfo> Fields { get; }
}

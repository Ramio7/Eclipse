<<<<<<< HEAD
using System.Reflection;

namespace UnityEngine.TestTools.Utils
{
    internal class AssemblyLoadProxy : IAssemblyLoadProxy
    {
        public IAssemblyWrapper Load(string assemblyString)
        {
            return new AssemblyWrapper(Assembly.Load(assemblyString));
        }
    }
}
=======
using System.Reflection;

namespace UnityEngine.TestTools.Utils
{
    internal class AssemblyLoadProxy : IAssemblyLoadProxy
    {
        public IAssemblyWrapper Load(string assemblyString)
        {
            return new AssemblyWrapper(Assembly.Load(assemblyString));
        }
    }
}
>>>>>>> origin/Fanrika_LevelDesing_Graphics

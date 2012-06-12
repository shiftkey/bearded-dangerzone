using System.Linq;
using System.Reflection;

namespace PortableClassLibrary
{
    public static class ReflectionTest
    {
        public static bool HasConstructors<T>()
        {
            return typeof(T).GetConstructors(BindingFlags.Instance).Any();   
        }
    }
}

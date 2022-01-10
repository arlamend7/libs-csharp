using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Libs.System.Utilities.Domains
{
    public static class AppDomainUtilities
    {
        public static IEnumerable<Type> GetTypes<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                                    .SelectMany(s => s.GetTypes())
                                    .Where(p => typeof(T).GetTypeInfo().IsAssignableFrom(p));
        }
    }
}

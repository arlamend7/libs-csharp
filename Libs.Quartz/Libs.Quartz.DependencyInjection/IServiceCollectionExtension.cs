using Libs.System.Utilities.Domains;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Libs.Quartz.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        ///     Add as transient all classes that implements IJob's interface 
        /// </summary>
        public static void AddJobs(this IServiceCollection services)
        {
            foreach (Type type in GetTypesAllIJobs())
            {
                services.AddTransient(type);
            }
        }

        private static IEnumerable<Type> GetTypesAllIJobs()
        {
            return AppDomainUtilities.GetTypes<IJob>()
                                     .Where(x => x.Name != nameof(IJob));
        }
    }
}

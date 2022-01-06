using Libs.System.Extensions.Attributes;
using System.Reflection;

namespace Libs.System.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToQueryString(this object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            string queryString = "?";
            foreach (PropertyInfo property in properties)
            {
                if (queryString != "?") queryString += "&";
                queryString += $"{property.GetCustomAttribute<QueryNameAttribute>().Name ?? property.Name}={property.GetValue(obj)}";
            }
            return queryString;
        }
    }
}

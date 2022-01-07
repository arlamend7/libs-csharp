using Libs.System.Extensions.Attributes;
using System;
using System.Reflection;

namespace Libs.System.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///     Return the object as query string
        /// </summary>
        /// <returns>Similar as '?name=value&name2=value'</returns>
        public static string ToQueryString(this object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            string queryString = "?";
            foreach (PropertyInfo property in properties)
            {
                if (queryString != "?") queryString += "&";
                queryString += $"{property.GetCustomAttribute<QueryNameAttribute>()?.Name ?? property.Name}={property.GetValue(obj)}";
            }
            return queryString;
        }

        public static bool IsNull(this object obj)
        {
            if (obj == null) return true; // obvious
            Type type = obj.GetType();
            if (type == string.Empty.GetType()) return string.IsNullOrEmpty((string)obj) || string.IsNullOrWhiteSpace((string)obj);
            if (!type.IsValueType) return obj == null; 
            if (Nullable.GetUnderlyingType(type) != null) return true; 
            return false;
        }

        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }
    }
}

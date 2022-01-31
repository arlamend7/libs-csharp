using Libs.System.Utilities.Enums.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Libs.System.Utilities.Enums
{
    public static class EnumUtilities
    {
        /// <summary>
        ///     Return all values of enum as EnumValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<EnumValue> GetValues<T>()
            where T : Enum
        {
            return GetValues<T, EnumValue>(enun => new EnumValue(enun))
                                        .OrderBy(x => x.Description);
        }

        /// <summary>
        ///     Return all values of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<TResult> GetValues<T, TResult>(Func<Enum, TResult> converter)
            where T : Enum
        {
            List<TResult> values = new List<TResult>();
            Type type = typeof(T);

            foreach (Enum enumerator in Enum.GetValues(type))
            {
                values.Add(converter.Invoke(enumerator));
            }

            return values;
        }

        public static TResult? GetByValue<TResult>(char value)
            where TResult : struct, Enum
        {
            if (Enum.TryParse(value.ToString(), out TResult result))
            {
                return result;
            }
            return default;
        }
        public static TResult? GetByValue<TResult>(int value)
            where TResult : struct, Enum
        {
            if (Enum.TryParse(value.ToString(), out TResult result))
            {
                return result;
            }
            return default;
        }
        public static TResult GetByName<TResult>(string name)
            where TResult : struct, Enum
        {
            if (Enum.TryParse(name, true, out TResult result))
            {
                return result;
            }
            return default;
        }
    }
}

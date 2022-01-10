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
        {
            List<TResult> values = new List<TResult>();
            Type type = typeof(T);

            foreach (Enum enumerator in Enum.GetValues(type))
            {
                values.Add(converter.Invoke(enumerator));
            }

            return values;
        }
    }
}

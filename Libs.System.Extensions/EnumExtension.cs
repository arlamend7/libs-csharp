using Libs.System.Extensions.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Libs.System.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        ///     Return the value of DescriptionAttribute in the enum
        /// </summary>
        /// <param name="value">Enumerador</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        /// <summary>
        ///     Return all values of enum as EnumValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<EnumValue> GetValues<T>()
        {
            return GetValues<T,EnumValue>(enun => new EnumValue()
            {
                Value = enun.ToString(),
                Description = enun.GetDescription()
            }).OrderBy(x => x.Description);
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

            foreach (string item in Enum.GetNames(type))
            {
                Enum enumerator = (Enum)Enum.Parse(type, item);

                values.Add(converter.Invoke(enumerator));
            }

            return values;
        }
    }
}

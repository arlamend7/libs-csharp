using System;
using System.ComponentModel;
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

            DescriptionAttribute attributes = fi.GetCustomAttribute<DescriptionAttribute>();

            return attributes != null ? attributes.Description : value.ToString();
        }

        public static int GetValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static char GetCharValue(this Enum value)
        {
            return Convert.ToChar(value);
        }

    }
}

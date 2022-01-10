using Libs.System.Extensions.Enums;
using System;
using System.Globalization;

namespace Libs.System.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Verify if it's not a weekend
        /// </summary>
        /// <param name="data">Data futura a ser comparada</param>
        /// <returns></returns>
        public static bool IsNotWeekend(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        ///     Verify if it's a weekend
        /// </summary>
        /// <param name="data">Data futura a ser comparada</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        ///     It's just work for portugues today
        /// </summary>
        /// <param name="data">Get date in full</param>
        /// <returns></returns>
        public static string GetDateInFull(this DateTime date, DateFullType fullType,  CultureInfo culture)
        {
            return date.ToString(fullType.GetDescription(), culture);
        }

        /// <summary>
        ///     It's just work for portugues today
        /// </summary>
        /// <param name="data">Get date in full</param>
        /// <returns></returns>
        public static string GetDateInFull(this DateTime date, DateFullType fullType)
        {
            return date.GetDateInFull(fullType, CultureInfo.CurrentCulture);
        }

        /// <summary>
        ///     It's just work for portugues today
        /// </summary>
        /// <param name="data">Get date in full</param>
        /// <returns></returns>
        public static string GetDateInFull(this DateTime date)
        {
            return date.GetDateInFull(DateFullType.Complete, CultureInfo.CurrentCulture);
        }
    }
}

using Libs.System.Extensions.Helpers;
using System;
using System.Collections.Generic;
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
        ///      Return all dates between startDay (current) and endDay
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> ToEndDate(this DateTime startDate, DateTime endDate)
        {
            return DateUtils.GetDatesInPeriod(startDate, endDate);
        }
        
        /// <summary>
        ///     It's just work for portugues today
        /// </summary>
        /// <param name="data">Get date in full</param>
        /// <returns></returns>
        public static string GetDateInFull(this DateTime date, CultureInfo culture = null)
        {
            culture = culture ?? new CultureInfo("pt-BR");
            DateTimeFormatInfo DateFormat = culture.DateTimeFormat;

            string month = culture.TextInfo.ToTitleCase(DateFormat.GetMonthName(date.Month));
            string DayOfWeek = culture.TextInfo.ToTitleCase(DateFormat.GetDayName(date.DayOfWeek));
            return DayOfWeek + ", " + date.Day + " de " + month + " de " + date.Year; // TODO : Can be set by culture
        }
    }
}

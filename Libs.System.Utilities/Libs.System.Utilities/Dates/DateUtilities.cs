using Libs.System.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Libs.System.Utilities.Dates
{
    public static class DateUtilities
    {
        public static IEnumerable<DateTime> GetDatesInPeriod(DateTime startDay, DateTime endDay, bool removeWeekend = false)
        {
            int diferencaDeDias = (int)endDay.Subtract(startDay).TotalDays;

            IEnumerable<DateTime> days = Enumerable
                .Range(0, diferencaDeDias)
                .Select(x => startDay.AddDays(x));

            if (removeWeekend)
                return days.Where(DateTimeExtensions.IsNotWeekend);

            return days;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Libs.System.Extensions.Helpers
{
    public class DateUtils
    {
        static Dictionary<string, int> MonthDict = new Dictionary<string, int>()
            {
                {"janeiro",1 },
                {"jan",1 },
                {"fevereiro",2 },
                {"fev",2 },
                {"março",3 },
                {"mar",3 },
                {"abril",4 },
                {"abr",4 },
                {"maio",5 },
                {"junho",6 },
                {"jun",6 },
                {"julho",7 },
                {"jul",7 },
                {"agosto",8 },
                {"ago",8 },
                {"setembro",9 },
                {"set",9 },
                {"outubro",10 },
                {"out",10 },
                {"novembro",11 },
                {"nov",11 },
                {"dezembro",12 },
                {"dez",12 },
            };


        public static int RecuperarMesPorTexto(string mes)
        {
            MonthDict.TryGetValue(mes.ToLower().Trim(), out int NumeroMes);
            return NumeroMes;
        }

        /// <summary>
        ///     Return all dates between startDay and endDay
        /// </summary>
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

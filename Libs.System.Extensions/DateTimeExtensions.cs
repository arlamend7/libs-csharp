using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Retorna os dias decorridos entre a data de inicio e a data de fim
        /// </summary>
        /// <param name="data">Data futura a ser comparada</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> RecuperarDiasDecorridos(DateTime dataInicio, DateTime dataFim, bool SomenteDiasUteis = false)
        {
            int diferencaDeDias = (int)dataFim.Subtract(dataInicio).TotalDays;

            IEnumerable<DateTime> days = Enumerable
                .Range(0, diferencaDeDias)
                .Select(x => dataInicio.AddDays(x));

            if (SomenteDiasUteis)
                return days.Where(VerificarDiaUtil);
            return days;
        }
        /// <summary>
        ///     Verifica se a data é um dia util
        /// </summary>
        /// <param name="data">Data futura a ser comparada</param>
        /// <returns></returns>
        public static bool VerificarDiaUtil(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}

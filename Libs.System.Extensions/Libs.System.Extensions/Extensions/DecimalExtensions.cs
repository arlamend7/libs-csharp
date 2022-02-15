using System.Globalization;

namespace Libs.System.Extensions
{
    public static class DecimalExtensions
    {
        private enum ToStringEnum { 
            Currency = 'C',
            Percent = 'P'
        }

        public static string ToCurrency(this decimal value, CultureInfo culture)
        {
            return value.ToString(ToStringEnum.Currency.GetCharValue().ToString(), culture);
        }

        public static string ToCurrency(this decimal value)
        {
            return value.ToString(ToStringEnum.Currency.GetCharValue().ToString(), CultureInfo.CurrentCulture);
        }

        public static string ToPercent(this decimal value, CultureInfo culture)
        {
            return value.ToString(ToStringEnum.Percent.GetCharValue().ToString(), culture);
        }

        public static string ToPercent(this decimal value)
        {
            return value.ToString(ToStringEnum.Percent.GetCharValue().ToString(), CultureInfo.CurrentCulture);
        }
    }
}

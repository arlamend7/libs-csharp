using NPOI.SS.UserModel;
using System;
using System.Globalization;

namespace Libs.NPOI.Extensions
{
    public static class ICellExtension
    {
        public static string GetStringCellInfo(this ICell cell)
        {
            if (cell is null)
                return null;
            cell.SetCellType(CellType.String);
            return cell.StringCellValue.ToUpper();
        }

        public static long? GetLongCellInfo(this ICell cell)
        {
            if (cell is null)
                return null;
            cell.SetCellType(CellType.String);
            string stringValue = cell.StringCellValue;
            if (long.TryParse(stringValue, out long longValue))
                return longValue;
            return null;
        }

        public static decimal? GetDecimalCellInfo(this ICell cell)
        {
            if (cell is null)
                return null;
            cell.SetCellType(CellType.String);
            string stringValue = cell.StringCellValue.Replace(".", ",");
            if (decimal.TryParse(stringValue,
                                 NumberStyles.Currency | NumberStyles.AllowExponent,
                                 new CultureInfo("pt-BR", false),
                                 out decimal decimalValue))
                return decimalValue;
            return null;
        }

        public static DateTime? GetDateCellInfo(this ICell cell)
        {
            if (cell is null)
                return null;
            return cell.DateCellValue;
        }
    }
}

using NPOI.SS.UserModel;

namespace Libs.NPOI.Extensions
{
    public static class ISheetExtension
    {
        public static void AutoSizeColumns(this ISheet FolhaCorrente, int? cellNumEnd = null, int cellNumStart = 0)
        {
            if (cellNumEnd is null)
                cellNumEnd = 20;
            for (int i = 0; i <= cellNumEnd; i++) FolhaCorrente.AutoSizeColumn(i);
        }
    }
}

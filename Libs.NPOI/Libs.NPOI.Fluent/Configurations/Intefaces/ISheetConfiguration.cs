namespace Libs.NPOI.Fluent.Configurations.Interfaces
{
    public interface ISheetConfiguration
    {
        /// <summary>
        ///  Ao Create proxima folha esta irá fazer autosize conforme seus dados
        /// </summary>
        /// <param name="cellNumEnd">Column de inicio</param>
        /// <param name="cellNumStart">ultima Column</param>
        void AutoSizeColumns(int? cellNumEnd = null, int cellNumStart = 0);
        ISheetConfiguration DefaultColumnWidth(int columnLenght);
        ISheetConfiguration DefaultRowHeight(short rowHeight);
        ISheetConfiguration ColumnsWidth(params int[] ColumnsWidth);
    }
}

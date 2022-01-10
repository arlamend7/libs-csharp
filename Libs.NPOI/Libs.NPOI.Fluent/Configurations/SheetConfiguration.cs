using Libs.NPOI.Fluent.Configurations.Interfaces;
using NPOI.SS.UserModel;
using System;

namespace Libs.NPOI.Fluent.Configurations
{
    public class SheetConfiguration : ISheetConfiguration
    {
        public ISheet CurrentSheet { get; set; }
        public Tuple<int?, int> Range { get; set; }
        public bool? AutoSize { get; set; }
        public SheetConfiguration(ISheet currentSheet)
        {
            CurrentSheet = currentSheet;
            AutoSize = true;
        }
        /// <summary>
        ///  Ao Create proxima folha esta irá fazer autosize conforme seus dados
        /// </summary>
        /// <param name="cellNumEnd"></param>
        /// <param name="cellNumStart"></param>
        public void AutoSizeColumns(int? cellNumEnd = null, int cellNumStart = 0)
        {
            AutoSize = true;
            Range = new Tuple<int?, int>(cellNumEnd, cellNumStart);
        }
        public ISheetConfiguration DefaultColumnWidth(int columnWidth)
        {
            AutoSize = false;
            CurrentSheet.DefaultColumnWidth = columnWidth;
            return this;
        }
        public ISheetConfiguration DefaultRowHeight(short rowHeight)
        {
            CurrentSheet.DefaultRowHeight = rowHeight;
            return this;
        }
        public ISheetConfiguration ColumnsWidth(params int[] ColumnsWidth)
        {
            AutoSize = false;
            for (int i = 0; i < ColumnsWidth.Length; i++)
            {
                CurrentSheet.SetColumnWidth(i, ColumnsWidth[i]);
            }
            return this;
        }

    }
}

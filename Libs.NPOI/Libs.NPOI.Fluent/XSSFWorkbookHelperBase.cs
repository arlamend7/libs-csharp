using Libs.NPOI.Fluent.Entities;
using Libs.NPOI.Fluent.Enums;
using Libs.NPOI.Fluent.Styles;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Libs.NPOI.Fluent
{
    public abstract class XSSFWorkbookHelperBase : XSSFWorkbookStyles
    {
        public IList<ISheet> Folhas { get; set; }
        public ISheet CurrentSheet { get; set; }
        public int ColumnCorrente { get; set; }
        public int LinhaCorrente { get; set; }
        protected int MaiorQuantidadeColumns { get; set; }
        protected XSSFWorkbookHelperBase() : base()
        {
            Folhas = new List<ISheet>();
            LinhaCorrente = 0;
            ColumnCorrente = 0;
        }
        protected int RecuperarColumnCorrente()
        {
            MaiorQuantidadeColumns = ColumnCorrente + 1;
            return ColumnCorrente++;
        }
        protected IRow CreateRowExcel()
        {
            return CurrentSheet.CreateRow(LinhaCorrente++);
        }
        protected void AjustarTamanho(IRow row, ICell cell, int tamanho, CellConfiguration configuration = null)
        {
            CellRangeAddress mergedRegion = new CellRangeAddress(row.RowNum, row.RowNum, cell.ColumnIndex, cell.ColumnIndex + (--tamanho));
            ColumnCorrente += tamanho;
            CurrentSheet.AddMergedRegion(mergedRegion);
            int borderType = (int)(configuration?.CellStyle?.BorderTop ?? BorderStyle.Thin);

            RegionUtil.SetBorderLeft(borderType, mergedRegion, CurrentSheet);
            RegionUtil.SetBorderRight(borderType, mergedRegion, CurrentSheet);
            RegionUtil.SetBorderTop(borderType, mergedRegion, CurrentSheet);
            RegionUtil.SetBorderBottom(borderType, mergedRegion, CurrentSheet);
        }
        public void CreateRow(IEnumerable<Tuple<CellConfiguration, int>> celulas, bool comFiltro = false)
        {

            IRow linha = CreateRowExcel();
            foreach (Tuple<CellConfiguration, int> celula in celulas)
            {
                AdicionarValorCelula(linha, new Tuple<CellConfiguration, int, CustomCellConfiguration>(celula.Item1, celula.Item2, null));
            }
            ColumnCorrente = 0;

            if (comFiltro)
            {
                CurrentSheet.SetAutoFilter(new CellRangeAddress(LinhaCorrente - 1, LinhaCorrente - 1, 0, celulas.Count() - 1));
            }
        }
        protected void AdicionarValorCelula(IRow linha, Tuple<CellConfiguration, int, CustomCellConfiguration> cellConfiguration)
        {
            ICell cell = linha.CreateCell(RecuperarColumnCorrente());

            if (cellConfiguration.Item2 != 1)
            {
                AjustarTamanho(linha, cell, cellConfiguration.Item2, cellConfiguration.Item1);
            }
            SetCellValue(cell, cellConfiguration.Item1);
            SetCellStyle(cell, cellConfiguration.Item1, cellConfiguration.Item3);
        }
        protected void SetCellValue(ICell cell, CellConfiguration cellConfiguration)
        {
            if (string.IsNullOrWhiteSpace(cellConfiguration.Value))
            {
                cellConfiguration.Type = CellTypeEnum.Blank;
            }

            switch (cellConfiguration.Type)
            {
                case CellTypeEnum.Porcent:
                case CellTypeEnum.Numeric:
                    cell.SetCellType(CellType.Numeric);
                    cell.SetCellValue(double.Parse(cellConfiguration.Value));
                    break;
                case CellTypeEnum.Date:
                case CellTypeEnum.Unknown:
                case CellTypeEnum.String:
                    cell.SetCellType(CellType.String);
                    cell.SetCellValue(cellConfiguration.Value);
                    break;
                case CellTypeEnum.Formula:
                    cell.SetCellType(CellType.Formula);
                    cell.SetCellFormula(cellConfiguration.Value);
                    break;
                case CellTypeEnum.Blank:
                    cell.SetCellType(CellType.Blank);
                    break;
                case CellTypeEnum.Boolean:
                    cell.SetCellType(CellType.Boolean);
                    cell.SetCellValue(bool.Parse(cellConfiguration.Value));
                    break;
                case CellTypeEnum.Error:
                    cell.SetCellType(CellType.Error);
                    cell.SetCellErrorValue(0);
                    break;
            }
        }
        protected void SetCellStyle(ICell cell, CellConfiguration cellConfiguration, CustomCellConfiguration customCellConfiguration)
        {
            ICellStyle estilo = Workbook.CreateCellStyle();
            estilo.CloneStyleFrom(GetStyle(cellConfiguration));

            if (customCellConfiguration != null)
            {
                estilo.FillForegroundColor = customCellConfiguration.BackgroundColor.Index;
                estilo.FillPattern = customCellConfiguration.Background;
            }
            cell.CellStyle = estilo;
        }
        protected ICellStyle GetStyle(CellConfiguration cellConfiguration)
        {
            if (cellConfiguration.HasStyle)
            {
                return cellConfiguration.CellStyle;
            }
            else if (cellConfiguration.Type == CellTypeEnum.Date)
            {
                return EstiloItemDateTime;
            }
            else if (cellConfiguration.Type == CellTypeEnum.Porcent)
            {
                return EstiloItemPercentual;
            }
            else
            {
                return EstiloItemRegular;
            }
        }
        public virtual Stream Export()
        {
            MemoryStream memoryStream = new MemoryStream();
            Workbook.Write(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            return new MemoryStream(bytes);
        }

    }
}

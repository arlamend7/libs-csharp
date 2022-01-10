using Libs.NPOI.Extensions;
using Libs.NPOI.Fluent.Configurations;
using Libs.NPOI.Fluent.Configurations.Interfaces;
using Libs.NPOI.Fluent.Entities;
using Libs.NPOI.Fluent.Enums;
using Libs.NPOI.Fluent.Interfaces;
using Libs.System.Extensions;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Libs.NPOI.Fluent
{
    public class XSSFWorkbookHelper : XSSFWorkbookHelperBase, IXSSFWorkbookCreateHelper
    {
        private SheetConfiguration SheetConfiguration { get; set; }

        public static IXSSFWorkbookCreateHelper ConfigurarCriacao()
        {
            return new XSSFWorkbookHelper();
        }

        public void CreateHeader(params (string, int)[] celulasSimples)
        {
            CreateRow(celulasSimples.Select(x => SimpleCellToConfiguration(x.Item1, x.Item2, true)), comFiltro: true);
            ColumnCorrente = 0;
        }
        public void CreateHeader(params string[] celulasSimples)
        {
            CreateRow(celulasSimples.Select(x => SimpleCellToConfiguration(x, 1, true)), comFiltro: true);
            ColumnCorrente = 0;
        }
        public void CreateRow(params (string, int)[] celulasSimples)
        {
            CreateRow(celulasSimples.Select(x => SimpleCellToConfiguration(x.Item1, x.Item2)));
            ColumnCorrente = 0;
        }
        public void CreateRow(params string[] celulasSimples)
        {
            CreateRow(celulasSimples.Select(x => SimpleCellToConfiguration(x, 1)));
            ColumnCorrente = 0;
        }

        public ISheetConfiguration CreateSheet(string nome)
        {
            if (CurrentSheet.IsNotNull() && SheetConfiguration.AutoSize.HasValue)
                CurrentSheet.AutoSizeColumns(SheetConfiguration.Range?.Item1, SheetConfiguration.Range?.Item2 ?? 0);

            CurrentSheet = Workbook.CreateSheet(nome);
            SheetConfiguration = new SheetConfiguration(CurrentSheet);
            LinhaCorrente = 0;
            ColumnCorrente = 0;
            Folhas.Add(CurrentSheet);
            return SheetConfiguration;
        }

        public ITableConfiguration<T> CreateTable<T>(IEnumerable<T> List)
        {
            return new TableConfiguration<T>(List, this);
        }
        public void CreateTable<T>(TableConfiguration<T> table)
        {
            IEnumerable<Tuple<CellConfiguration, int>> cellsHeader = table.Headers.Select((x, index) => SimpleCellToConfiguration(x, table.Columns[index], true));
            CreateRow(cellsHeader, comFiltro: true);

            foreach (T registro in table.List)
            {
                IRow linha = CreateRowExcel();
                table.Converters.Select((x, index) => CellVariantToConfiguration(x, table.Columns[index], registro))
                                .ToList()
                                .ForEach(value => AdicionarValorCelula(linha, value));
                ColumnCorrente = 0;
            }
        }

        public override Stream Export()
        {
            if (CurrentSheet != null && SheetConfiguration.AutoSize.HasValue)
                CurrentSheet.AutoSizeColumns(SheetConfiguration.Range?.Item1, SheetConfiguration.Range?.Item2 ?? 0);

            return base.Export();
        }

        private Tuple<CellConfiguration, int> SimpleCellToConfiguration(string celulaSimples, int columns, bool cabecalho = false)
        {
            CellConfiguration configuration = new CellConfiguration()
            {
                Value = celulaSimples,
                CellStyle = cabecalho ? EstiloCabecalho : EstiloItemRegular,
                Type = CellTypeEnum.String
            };

            return new Tuple<CellConfiguration, int>(configuration, columns);
        }
        private Tuple<CellConfiguration, int, CustomCellConfiguration> CellVariantToConfiguration<T>(CellVariantConfiguration<T> cellVariant, int columns, T registro)
        {
            CellConfiguration configuration = cellVariant.Configuration.Invoke(registro);
            CustomCellConfiguration customCellConfiguration = cellVariant.Customizable?.Invoke(registro);
            return new Tuple<CellConfiguration, int, CustomCellConfiguration>(configuration, columns, customCellConfiguration);
        }
    }
}

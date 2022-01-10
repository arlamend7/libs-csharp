using Libs.NPOI.Fluent.Configurations.Interfaces;
using Libs.NPOI.Fluent.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Libs.NPOI.Fluent.Interfaces
{
    public interface IXSSFWorkbookCreateHelper
    {
        void CreateHeader(params (string, int)[] celulasSimples);
        void CreateHeader(params string[] celulasSimples);
        void CreateRow(params (string, int)[] celulasSimples);
        void CreateRow(params string[] celulasSimples);
        void CreateRow(IEnumerable<Tuple<CellConfiguration, int>> celulas, bool comFiltro = false);
        ISheetConfiguration CreateSheet(string nome);
        ITableConfiguration<T> CreateTable<T>(IEnumerable<T> List);
        Stream Export();
    }
}

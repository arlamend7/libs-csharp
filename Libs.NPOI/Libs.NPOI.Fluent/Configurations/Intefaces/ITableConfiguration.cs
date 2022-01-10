using Libs.NPOI.Fluent.Entities;
using Libs.NPOI.Fluent.Enums;
using System;

namespace Libs.NPOI.Fluent.Configurations.Interfaces
{
    public interface ITableConfiguration<T>
    {
        ITableConfiguration<T> EmptyColumn();
        ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao);
        ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, int tamanho);
        ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, CellTypeEnum type);
        ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, Func<T, CustomCellConfiguration> custom);
        ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, int tamanho, CellTypeEnum type);
        ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, int tamanho, Func<T, CustomCellConfiguration> custom);
        ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, int tamanho, CellTypeEnum type, Func<T, CustomCellConfiguration> custom);
        ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, CellTypeEnum type, Func<T, CustomCellConfiguration> custom);
        void Create();

    }
}

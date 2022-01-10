using Libs.NPOI.Fluent.Configurations.Interfaces;
using Libs.NPOI.Fluent.Entities;
using Libs.NPOI.Fluent.Enums;
using System;
using System.Collections.Generic;

namespace Libs.NPOI.Fluent.Configurations
{
    public class TableConfiguration<T> : ITableConfiguration<T>
    {
        public IEnumerable<T> List { get; set; }
        public List<CellVariantConfiguration<T>> Converters { get; set; }
        public List<int> Columns { get; set; }
        public List<string> Headers { get; set; }
        private XSSFWorkbookHelper Workbook { get; set; }
        public TableConfiguration(IEnumerable<T> list, XSSFWorkbookHelper workbook)
        {
            List = list;
            Converters = new List<CellVariantConfiguration<T>>();
            Headers = new List<string>();
            Columns = new List<int>();
            Workbook = workbook;
        }
        public ITableConfiguration<T> EmptyColumn()
        {
            SaveInfo("", new CellVariantConfiguration<T>()
            {
                Configuration = value => new CellConfiguration() { Type = CellTypeEnum.Blank },
                Customizable = null
            }, 1);
            return this;
        }
        public ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao)
        {
            SaveInfo(cabecalho, x => ColumnConfiguration(conversao, x));
            return this;
        }
        public ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, int tamanho)
        {
            SaveInfo(cabecalho, x => ColumnConfiguration(conversao, x), tamanho);
            return this;
        }
        public ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, CellTypeEnum type)
        {
            SaveInfo(cabecalho, x => ColumnConfiguration(conversao, x, type));
            return this;
        }
        public ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, int tamanho, CellTypeEnum type)
        {
            SaveInfo(cabecalho, x => ColumnConfiguration(conversao, x, type), tamanho);
            return this;
        }
        public ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, Func<T, CustomCellConfiguration> custom)
        {
            SaveInfo(cabecalho, x => ColumnConfiguration(conversao, x), 1, custom);
            return this;
        }
        public ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, CellTypeEnum type, Func<T, CustomCellConfiguration> custom)
        {
            SaveInfo(cabecalho, x => ColumnConfiguration(conversao, x, type), 1, custom);
            return this;
        }
        public ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, int tamanho, Func<T, CustomCellConfiguration> custom)
        {
            SaveInfo(cabecalho, x => ColumnConfiguration(conversao, x), tamanho, custom);
            return this;
        }
        public ITableConfiguration<T> Column<Tkey>(string cabecalho, Func<T, Tkey> conversao, int tamanho, CellTypeEnum type, Func<T, CustomCellConfiguration> custom)
        {
            SaveInfo(cabecalho, x => ColumnConfiguration(conversao, x, type), tamanho, custom);
            return this;
        }
        private CellConfiguration ColumnConfiguration<Tkey>(Func<T, Tkey> conversao, T value)
        {
            return new CellConfiguration()
            {
                Value = conversao.Invoke(value)?.ToString(),
                Type = ReturnColumnType<Tkey>(),
            };
        }
        private CellConfiguration ColumnConfiguration<Tkey>(Func<T, Tkey> conversao, T value, CellTypeEnum type)
        {
            return new CellConfiguration()
            {
                Value = conversao.Invoke(value)?.ToString(),
                Type = type,
            };
        }
        private void SaveInfo(string cabecalho, Func<T, CellConfiguration> conversao, int Tamanho = 1, Func<T, CustomCellConfiguration> custom = null)
        {
            SaveInfo(cabecalho, new CellVariantConfiguration<T>()
            {
                Configuration = conversao,
                Customizable = custom
            }, Tamanho);
        }
        private void SaveInfo(string cabecalho, CellVariantConfiguration<T> conversao, int Tamanho)
        {
            Columns.Add(Tamanho);
            Headers.Add(cabecalho);
            Converters.Add(conversao);
        }
        private CellTypeEnum ReturnColumnType<TKey>()
        {
            TypeCode tipo = Type.GetTypeCode(typeof(TKey));
            switch (tipo)
            {
                case TypeCode.Boolean:
                    return CellTypeEnum.Boolean;
                case TypeCode.DBNull:
                case TypeCode.Empty:
                    return CellTypeEnum.Blank;
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int64:
                case TypeCode.Int32:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.SByte:
                    return CellTypeEnum.Numeric;
                case TypeCode.DateTime:
                    return CellTypeEnum.Date;
                case TypeCode.String:
                case TypeCode.Char:
                    return CellTypeEnum.String;
                case TypeCode.Object:
                    return CellTypeEnum.Unknown;
                default:
                    return CellTypeEnum.Error;
            }
        }

        public void Create()
        {
            Workbook.CreateTable(this);
        }
    }
}

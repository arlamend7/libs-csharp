using System;

namespace Libs.NPOI.Fluent.Entities
{
    public class CellVariantConfiguration<T>
    {
        public Func<T, CellConfiguration> Configuration { get; set; }
        public Func<T, CustomCellConfiguration> Customizable { get; set; }
    }
}

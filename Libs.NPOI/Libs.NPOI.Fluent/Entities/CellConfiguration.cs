using Libs.NPOI.Fluent.Enums;
using NPOI.SS.UserModel;

namespace Libs.NPOI.Fluent.Entities
{
    public class CellConfiguration
    {
        public string Value { get; set; }
        public CellTypeEnum Type { get; set; }
        public ICellStyle CellStyle { get; set; }
        public bool HasStyle => CellStyle != null;
        public CellConfiguration()
        {
            Type = CellTypeEnum.String;
        }
    }
    
}

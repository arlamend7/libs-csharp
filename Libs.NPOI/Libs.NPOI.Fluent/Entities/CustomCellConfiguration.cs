using NPOI.SS.UserModel;

namespace Libs.NPOI.Fluent.Entities
{
    public class CustomCellConfiguration
    {
        public IFont Font { get; set; }
        public FillPattern Background { get; set; }
        public IndexedColors BackgroundColor { get; set; }
    }
}

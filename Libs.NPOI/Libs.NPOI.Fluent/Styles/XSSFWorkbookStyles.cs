using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Libs.NPOI.Fluent.Styles
{
    public abstract class XSSFWorkbookStyles
    {
        public IWorkbook Workbook { get; }

        public ICellStyle EstiloCabecalho { get; set; }
        public ICellStyle EstiloItemRegular { get; set; }
        public ICellStyle EstiloItemPercentual { get; set; }
        public ICellStyle EstiloItemDateTime { get; set; }
        protected XSSFWorkbookStyles()
        {
            Workbook = new XSSFWorkbook();
            CreateEstiloCabecario();
            CreateEstiloItem();
            CreateEstiloItemData();
            CreateEstiloItemPercentual();
        }
        private ICellStyle CreateEstilo(IFont Font)
        {
            ICellStyle estiloItem = Workbook.CreateCellStyle();
            estiloItem.BorderBottom = BorderStyle.Thin;
            estiloItem.BorderLeft = BorderStyle.Thin;
            estiloItem.BorderRight = BorderStyle.Thin;
            estiloItem.BorderTop = BorderStyle.Thin;
            estiloItem.SetFont(Font);
            return estiloItem;
        }
        private ICellStyle CreateEstilo()
        {
            IFont Font;
            Font = Workbook.CreateFont();
            Font.FontHeightInPoints = 11;
            Font.Color = IndexedColors.Black.Index;
            

            ICellStyle estiloItem = Workbook.CreateCellStyle();
            estiloItem.BorderBottom = BorderStyle.Thin;
            estiloItem.BorderLeft = BorderStyle.Thin;
            estiloItem.BorderRight = BorderStyle.Thin;
            estiloItem.BorderTop = BorderStyle.Thin;
            estiloItem.SetFont(Font);
            return estiloItem;
        }
        private void CreateEstiloCabecario()
        {
            IFont FontCabecalho = Workbook.CreateFont();
            FontCabecalho.IsBold = true;
            FontCabecalho.FontHeightInPoints = 11;
            FontCabecalho.Color = IndexedColors.White.Index;

            EstiloCabecalho = CreateEstilo(FontCabecalho);
            EstiloCabecalho.FillForegroundColor = IndexedColors.DarkBlue.Index;
            EstiloCabecalho.FillPattern = FillPattern.SolidForeground;
            EstiloCabecalho.Alignment = HorizontalAlignment.Center;
            EstiloCabecalho.VerticalAlignment = VerticalAlignment.Center;
        }
        private void CreateEstiloItem()
        {
            EstiloItemRegular = CreateEstilo();
            EstiloItemRegular.Alignment = HorizontalAlignment.Left;
            EstiloItemRegular.VerticalAlignment = VerticalAlignment.Center;
        }
        private void CreateEstiloItemPercentual()
        {
            EstiloItemPercentual = CreateEstilo();
            EstiloItemPercentual.Alignment = HorizontalAlignment.Center;
            EstiloItemPercentual.DataFormat = Workbook.CreateDataFormat().GetFormat("0.00%");
        }
        private void CreateEstiloItemData()
        {
            EstiloItemDateTime = CreateEstilo();
            EstiloItemDateTime.Alignment = HorizontalAlignment.Center;
            EstiloItemDateTime.DataFormat = Workbook.CreateDataFormat().GetFormat("dd/MM/yyyy HH:mm:ss");
        }
    }
}
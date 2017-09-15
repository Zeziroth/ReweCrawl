using Microsoft.Office.Interop.Excel;
using System;

namespace Main
{
    class ExcelController
    {
        public Application excel { get; set; }
        public Workbook workbook { get; set; }
        public Worksheet sheet { get; set; }

        public ExcelController(string path)
        {
            Application excel = new Application();
            workbook = excel.Workbooks.Open(path);
            excel.Visible = true;
            sheet = workbook.Worksheets[1];
        }

        private int lastRow()
        {
            Range last = sheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);

            int lastUsedRow = last.Row;
            return sheet.UsedRange.Rows.Count;
        }

        public void InsertRow(ReweProdukt product)
        {
            try
            {
                int newRow = lastRow();
                //Console.WriteLine(newRow);
                sheet.Cells[newRow + 1, 1].Value = product.imgUrl;
                sheet.Cells[newRow + 1, 2].Value = product.productName;
                sheet.Cells[newRow + 1, 3].Value = product.servingSize + " " + product.servingEinheit;
                sheet.Cells[newRow + 1, 4].Value = product.kcal.value;
                sheet.Cells[newRow + 1, 5].Value = product.fett.value;
                sheet.Cells[newRow + 1, 6].Value = product.kohlenhydrate.value;
                sheet.Cells[newRow + 1, 7].Value = product.eiweiß.value;
                sheet.Cells[newRow + 1, 8].Value = product.salz.value;
                sheet.Cells[newRow + 1, 9].Value = product.price;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
}
    }
}

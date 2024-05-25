namespace ExcelAI.Domain.Excel
{
    public class ExcelService : IExcelService
    {
        public IWorkbook FromCSV(DataTable.DataTable dataTable)
        {
            FileInfo templateFile = new FileInfo("template.xlsx");
            FileInfo outFile = new FileInfo(Path.GetRandomFileName() + ".xlsx");

            IWorkbook workbook = new Workbook(outFile);

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(templateFile, outFile))
            {
                fastExcel.Write(dataTable.Data, "Лист1", true);
            }

            return workbook;
        }
    }
}

using ExcelAI.Domain.DataTable;

namespace ExcelAI.Domain.Excel
{
    public interface IExcelService
    {
        public IWorkbook FromCSV(DataTable.DataTable dataTable);
    }
}

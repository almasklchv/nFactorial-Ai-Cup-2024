namespace ExcelAI.Domain.Excel
{
    public class Workbook : IWorkbook
    {
        public FileInfo FileInfo { get; set; }

        public Workbook(FileInfo file)
            => this.FileInfo = file;
    }
}

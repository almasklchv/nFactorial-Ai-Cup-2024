namespace ExcelAI.Domain.DataTable
{
    public interface IDataTable
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public string[][] Data { get; set; }

        public abstract static IDataTable FromCSV(string csv);
    }
}

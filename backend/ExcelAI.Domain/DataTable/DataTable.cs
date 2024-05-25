namespace ExcelAI.Domain.DataTable
{
    public class DataTable : IDataTable
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        
        public string[][] Data { get; set; }

        public static IDataTable FromCSV(string csv)
        {
            csv = csv.Replace("```", "");
            var rows = csv.Split("\n")
                          .Where(row => row != string.Empty);

            string[][] table = new string[][] { };

            foreach (string row in rows)
            {
                table = table.Append(row.Split(",")).ToArray();
            }

            IDataTable dataTable = new DataTable();
            dataTable.Data = table;
            dataTable.Rows = table.Count();
            dataTable.Columns = table.First().Count();
            return dataTable;
        }
    }
}

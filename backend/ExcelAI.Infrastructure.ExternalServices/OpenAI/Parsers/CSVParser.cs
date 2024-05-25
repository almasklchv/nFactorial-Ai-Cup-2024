using ExcelAI.Domain.DataTable;
using System.Text.RegularExpressions;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.Parsers
{
    public class CSVParser : IResponseFormatParser
    {
        public IDataTable ParseToDataTable(string rawData)
        {
            Regex pattern = new Regex(@"```([^;]*)```");
            var data = pattern.Matches(rawData).ElementAt(0).Value;

            if(data == string.Empty)
            {
                throw new Exception("\nERROR:\n\tAn error occured while processing response data: there is no CSV data in respone");
            }

            return DataTable.FromCSV(data);
        }
    }
}

using ExcelAI.Domain.DataTable;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.Parsers
{
    public interface IResponseFormatParser
    {
        public IDataTable ParseToDataTable(string data);
    }
}

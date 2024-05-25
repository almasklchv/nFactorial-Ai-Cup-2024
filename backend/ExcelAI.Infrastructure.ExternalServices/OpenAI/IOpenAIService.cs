using ExcelAI.Domain.DataTable;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI
{
    public interface IOpenAIService
    {
        public Task<DataTable> GetDataTableFromImages(IEnumerable<FileInfo> files,
                                                      string? prompt);

        public Task<DataTable> GetDataTableFromImagesWithSpecifiedHeaders(IEnumerable<string> headers,
                                                                            IEnumerable<FileInfo> files,
                                                                            string? prompt);

        public Task<DataTable> GetDataTableFromImagesWithSpecifiedHeaders(IEnumerable<string> headers,
                                                                            IDataTable userDefinedTable,
                                                                            IEnumerable<FileInfo> files,
                                                                            string? prompt);
    }
}

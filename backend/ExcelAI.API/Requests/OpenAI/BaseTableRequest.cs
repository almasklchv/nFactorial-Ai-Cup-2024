namespace ExcelAI.API.Requests.OpenAI
{
    public abstract class BaseTableRequest
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}

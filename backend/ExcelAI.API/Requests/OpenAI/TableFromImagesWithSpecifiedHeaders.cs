namespace ExcelAI.API.Requests.OpenAI
{
    public class TableFromImagesWithSpecifiedHeaders : BaseTableRequest
    {
        public string[] Headers { get; set; }
    }
}

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.Configuration
{
    public interface IPromtsConfiguration
    {
        public string GetStandartPromt(string methodName);
    }
}

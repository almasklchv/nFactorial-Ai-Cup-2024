using OpenAI_API.Models;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.QueryConfigurations
{
    public interface IQueryConfiguration
    {
        Model Model { get; set; }
        double? Temprature { get; set; }
        double? TopP { get; set; }
        int? ChoisesNum { get; set; }
        int? MaxTokens { get; set; }
        double? FrequencyPenalty { get; set; }
        double? PresencePenalty { get; set; }
        string[] stopSequences { get; set; }
    }
}
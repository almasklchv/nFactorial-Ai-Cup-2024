using OpenAI_API.Models;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.QueryConfigurations
{
    public class DefaultQueryConfiguration : IQueryConfiguration
    {
        public Model Model { get; set; } = Model.GPT4_Vision;
        public double? Temprature { get; set; } = 0.1;
        public double? TopP { get; set; } = null;
        public int? ChoisesNum { get; set; } = 1;
        public int? MaxTokens { get; set; } = 4096;
        public double? FrequencyPenalty { get; set; } = null;
        public double? PresencePenalty { get; set; } = null;
        public string[] stopSequences { get; set; } = new string[] { };
    }
}

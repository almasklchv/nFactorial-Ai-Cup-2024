using Microsoft.Extensions.Configuration;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.Configuration
{
    public class PromtsConfiguration : IPromtsConfiguration
    {
        private readonly IConfiguration configuration;

        public PromtsConfiguration(IConfiguration configuration)
            => this.configuration = configuration;

        public string GetStandartPromt(string methodName)
        {
            IConfigurationSection section = configuration.GetSection("DefaultPromts");
            string prompt = section[methodName] ?? throw new NullReferenceException();
            return prompt;
        }
    }
}

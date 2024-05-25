using ExcelAI.Infrastructure.ExternalServices.OpenAI.QueryConfigurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenAI_API.Chat;

using RemoteAPI = OpenAI_API.OpenAIAPI;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.API
{
    public class OpenAIAPI : IOpenAIAPI
    {
        private readonly IConfiguration serviceConfiguration;
        private readonly ILogger<IOpenAIAPI> logger;
        private readonly IQueryConfiguration queryConfiguration;

        private readonly string APIKey;

        public OpenAIAPI(IConfiguration serviceConfiguration,
                        ILogger<IOpenAIAPI> logger, 
                        IQueryConfiguration queryConfiguration)
        {
            this.serviceConfiguration = serviceConfiguration;
            this.logger = logger;
            this.queryConfiguration = queryConfiguration;

            this.APIKey = this.serviceConfiguration["ApiKey"] ?? 
                throw new Exception("\nERROR:\n\tOpenAI Api key has not specified");
        }

        public async Task<ChatResult> Request(ChatMessage message, IQueryConfiguration? conf = null)
        {
            RemoteAPI api = new RemoteAPI(this.APIKey);

            if (conf == null)
            {
                conf = this.queryConfiguration;
            }

            return await api.Chat.CreateChatCompletionAsync(
                messages: new List<ChatMessage>() { message },
                model: conf.Model,
                temperature: conf.Temprature,
                numOutputs: conf.ChoisesNum,
                max_tokens: conf.MaxTokens
                );
        }
    }
}

using ExcelAI.Infrastructure.ExternalServices.OpenAI.QueryConfigurations;
using OpenAI_API.Chat;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.API
{
    public interface IOpenAIAPI
    {
        public Task<ChatResult> Request(ChatMessage message, IQueryConfiguration? configuration);
    }
}

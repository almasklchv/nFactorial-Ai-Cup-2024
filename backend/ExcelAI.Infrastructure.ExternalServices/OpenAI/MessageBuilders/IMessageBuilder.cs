using OpenAI_API.Chat;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.MessageBuilders
{
    public interface IMessageBuilder
    {
        public IMessageBuilder SetRole(ChatMessageRole role);
        public IMessageBuilder SetPrompt(string prompt);
        public IMessageBuilder SetImages(IEnumerable<FileInfo> files);

        public ChatMessage Construct();
        public void Reset();
    }
}

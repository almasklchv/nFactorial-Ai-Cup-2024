using OpenAI_API.Chat;

using static OpenAI_API.Chat.ChatMessage;

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI.MessageBuilders
{
    public class MessageBuilder : IMessageBuilder
    {
        private ChatMessage Message { get; set; }
            = new ChatMessage();

        public IMessageBuilder SetRole(ChatMessageRole role)
        {
            Message.Role = role;
            return this;
        }

        public IMessageBuilder SetPrompt(string prompt)
        {
            Message.TextContent = prompt;
            return this;
        }

        public IMessageBuilder SetImages(ImageInput image)
        {
            Message.Images.Add(image);
            return this;
        }
        public IMessageBuilder SetImages(IEnumerable<ImageInput> images)
        {
            Message.Images.AddRange(images);
            return this;
        }
        public IMessageBuilder SetImages(IEnumerable<FileInfo> files)
        {
            Message.Images = PrepareImages(files);
            return this;
        }

        public ChatMessage Construct()
        {
            return Message;
        }
        public void Reset()
        {
            Message = new ChatMessage();
        }

        private List<ImageInput> PrepareImages(IEnumerable<FileInfo> files)
        {
            List<ImageInput> images = new List<ImageInput>();
            foreach (FileInfo file in files)
            {
                ImageInput image = ImageInput.FromFile(file.FullName);
                images.Add(image);
            }
            return images;
        }
    }
}

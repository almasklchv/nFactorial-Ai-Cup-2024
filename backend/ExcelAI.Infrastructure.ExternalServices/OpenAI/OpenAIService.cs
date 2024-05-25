using Microsoft.Extensions.Logging;
using ExcelAI.Domain.DataTable;
using OpenAI_API.Chat;
using ExcelAI.Infrastructure.ExternalServices.OpenAI.MessageBuilders;
using ExcelAI.Infrastructure.ExternalServices.OpenAI.API;
using ExcelAI.Infrastructure.ExternalServices.OpenAI.Parsers;
using ExcelAI.Infrastructure.ExternalServices.OpenAI.Configuration;
using ExcelAI.Infrastructure.ExternalServices.MetricsBot.Data;
using ExcelAI.Infrastructure.ExternalServices.MetricsBot;

//TODO:
//  0) choises num?

namespace ExcelAI.Infrastructure.ExternalServices.OpenAI
{
    public class OpenAIService : IOpenAIService
    {
        private readonly ILogger<IOpenAIService> logger;

        private readonly IMessageBuilder messageBuilder;
        private readonly IOpenAIAPI remoteAPI;
        private readonly IPromtsConfiguration promtsConfiguration;

        private readonly MetricsTelegramService metrics;

        public OpenAIService(ILogger<IOpenAIService> logger,
                             IMessageBuilder messageBuilder,
                             IOpenAIAPI remoteAPI,
                             IPromtsConfiguration promtsConfiguration,
                             MetricsTelegramService metrics)
        {
            this.logger = logger;
            this.messageBuilder = messageBuilder;
            this.remoteAPI = remoteAPI;
            this.promtsConfiguration = promtsConfiguration;
            this.metrics = metrics;
        }


        public async Task<DataTable> GetDataTableFromImages(IEnumerable<FileInfo> files, string? prompt = null)
        {
            if(prompt is null)
            {
                prompt = this.promtsConfiguration.GetStandartPromt("GetDataTableFromImages");
            }

            ChatMessage message = this.messageBuilder.SetRole(ChatMessageRole.User)
                                                     .SetPrompt(prompt)
                                                     .SetImages(files)
                                                     .Construct();

            var result = await this.remoteAPI.Request(message, null);


            MetricData metricData = new MetricData()
            {
                RequestType = MetricData.UserRequestType.TableFromImages,
                ImagesCount = files.Count(),
                ImagesWeightKB = files.Sum(f => f.Length) / (1024),
                TokensSpent = result.Usage.CompletionTokens
            };
            await this.metrics.SendMetric(metricData);

            // choises may be more, than one
            var rawResponse = result.Choices.ElementAt(0).Message.TextContent;

            DataTable table = this.CreateTable(rawResponse);
            return table;
        }

        public async Task<DataTable> GetDataTableFromImagesWithSpecifiedHeaders(IEnumerable<string> headers, IEnumerable<FileInfo> files, string? prompt = null)
        {
            if (prompt is null)
            {
                prompt = this.promtsConfiguration.GetStandartPromt("GetDataTableFromImagesWithSpecifiedHeaders");
            }

            prompt = prompt + string.Concat(", ", String.Join(", ", headers));

            ChatMessage message = this.messageBuilder.SetRole(ChatMessageRole.User)
                                                     .SetPrompt(prompt)
                                                     .SetImages(files)
                                                     .Construct();

            var result = await this.remoteAPI.Request(message, null);

            MetricData metricData = new MetricData()
            {
                RequestType = MetricData.UserRequestType.TableFromImagesWithHeaders,
                ImagesCount = files.Count(),
                ImagesWeightKB = files.Sum(f => (double)f.Length) / (1024),
                TokensSpent = result.Usage.CompletionTokens
            };
            await this.metrics.SendMetric(metricData);

            // choises may be more, than one
            var rawResponse = result.Choices.ElementAt(0).Message.TextContent;

            DataTable table = this.CreateTable(rawResponse);
            return table;
        }

        public async Task<DataTable> GetDataTableFromImagesWithSpecifiedHeaders(IEnumerable<string> headers, IDataTable userDefinedTable, IEnumerable<FileInfo> files, string? prompt = null)
        {
            throw new NotImplementedException();
        }

        private DataTable CreateTable(string rawResponse)
        {
            IResponseFormatParser parser = new CSVParser();
            DataTable table = parser.ParseToDataTable(rawResponse) as DataTable
                ?? throw new InvalidCastException("\nERROR:\n\tCan not cast IDataTable to DataTable");
            return table;
        }
    }
}

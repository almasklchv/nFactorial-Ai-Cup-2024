using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExcelAI.Infrastructure.ExternalServices.MetricsBot.Data
{
    public class MetricData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("request_type")]
        public UserRequestType RequestType { get; set; }

        [JsonProperty("images_count")]
        public int ImagesCount { get; set; }

        [JsonProperty("images_weight_KB")]
        public double ImagesWeightKB { get; set; }

        [JsonProperty("tokens_spent")]
        public int TokensSpent { get; set; }


        public enum UserRequestType
        {
            TableFromImages,
            TableFromImagesWithHeaders,
            TableFromImagesWithHeadersAndTable
        }
    }
}

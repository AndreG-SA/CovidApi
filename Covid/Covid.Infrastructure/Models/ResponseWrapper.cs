using Newtonsoft.Json;

namespace Covid.Infrastructure.Models
{
    public class ResponseWrapper<TResponse> where TResponse : class
    {
        [JsonProperty(propertyName: "get")]
        public string Get { get; set; }

        [JsonProperty(propertyName: "parameters")]
        public object Parameters { get; set; }

        [JsonProperty(propertyName: "errors")]
        public object Errors { get; set; }

        [JsonProperty(propertyName: "results")]
        public int Results { get; set; }

        [JsonProperty(propertyName: "response")]
        public TResponse Response { get; set; }
    }
}

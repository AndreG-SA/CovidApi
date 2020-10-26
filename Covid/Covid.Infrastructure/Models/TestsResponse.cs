using Newtonsoft.Json;

namespace Covid.Infrastructure.Models
{
    public class TestsResponse
    {
        [JsonProperty(propertyName: "1M_pop")]
        public string _1M_pop { get; set; }

        [JsonProperty(propertyName: "total")]
        public int? Total { get; set; }
    }
}

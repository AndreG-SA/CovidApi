using Newtonsoft.Json;
using System;

namespace Covid.Infrastructure.Models
{
    public class StatisticsResponse
    {
        [JsonProperty(propertyName: "continent")]
        public string Continent { get; set; }

        [JsonProperty(propertyName: "country")]
        public string Country { get; set; }

        [JsonProperty(propertyName: "population")]
        public int? Population { get; set; }

        [JsonProperty(propertyName: "cases")]
        public CasesResponse Cases { get; set; }

        [JsonProperty(propertyName: "deaths")]
        public DeathsResponse Deaths { get; set; }

        [JsonProperty(propertyName: "tests")]
        public TestsResponse Tests { get; set; }

        [JsonProperty(propertyName: "day")]
        public string Day { get; set; }

        [JsonProperty(propertyName: "time")]
        public DateTime Time { get; set; }
    }

}

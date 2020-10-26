using Newtonsoft.Json;

namespace Covid.Api.Models
{
    public class CountryResponse
    {
        [JsonProperty("continent")]
        public string Continent { get; }

        [JsonProperty("country")]
        public string Country { get; }

        [JsonProperty("new")]
        public TotalResponse New { get; }

        [JsonProperty("active")]
        public TotalResponse Active { get; }

        [JsonProperty("deaths")]
        public TotalResponse Deaths { get; }

        public CountryResponse(string continent, string country, TotalResponse @new, TotalResponse active, TotalResponse deaths)
        {
            Continent = continent;
            Country = country;
            New = @new;
            Active = active;
            Deaths = deaths;
        }
    }
}

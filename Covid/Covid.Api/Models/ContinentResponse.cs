using Newtonsoft.Json;

namespace Covid.Api.Models
{

    public class ContinentResponse
    {
        [JsonProperty("continent")]
        public string Continent { get; }

        [JsonProperty("new")]
        public TotalResponse New { get; }

        [JsonProperty("active")]
        public TotalResponse Active { get; }

        [JsonProperty("deaths")]
        public TotalResponse Deaths { get; }

        public ContinentResponse(string continent, TotalResponse @new, TotalResponse active, TotalResponse deaths)
        {
            Continent = continent;
            New = @new;
            Active = active;
            Deaths = deaths;
        }
    }
}

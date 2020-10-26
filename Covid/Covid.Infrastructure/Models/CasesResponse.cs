using Newtonsoft.Json;

namespace Covid.Infrastructure.Models
{
    public class CasesResponse
    {
        [JsonProperty(propertyName: "new")]
        public string New { get; set; }
        
        [JsonProperty(propertyName: "active")]
        public int Active { get; set; }
        
        [JsonProperty(propertyName: "critical")]
        public int Critical { get; set; }
        
        [JsonProperty(propertyName: "recovered")]
        public int Recovered { get; set; }
        
        [JsonProperty(propertyName: "1M_pop")]
        public string _1M_pop { get; set; }
        
        [JsonProperty(propertyName: "total")]
        public int Total { get; set; }
    }

}

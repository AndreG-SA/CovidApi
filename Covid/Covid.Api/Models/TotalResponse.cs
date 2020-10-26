using Newtonsoft.Json;

namespace Covid.Api.Models
{
    public class TotalResponse
    {
        [JsonProperty("total")]
        public int Total { get; }

        [JsonProperty("Percent")]
        public int Percent { get; }

        public TotalResponse(int total, int percent)
        {
            Total   = total;
            Percent = percent;
        }  
    }
}

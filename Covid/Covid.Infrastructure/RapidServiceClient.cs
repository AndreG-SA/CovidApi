using Covid.Domain.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid.Infrastructure
{
    /// <summary>
    /// Concrete implementation for Rapid Api client, will handle API Key for all get requests
    /// As per the documentation it is a good idea to reuse the http client, so we can add this as a singleton
    /// </summary>
    public class RapidServiceClient : ISecuredServiceClient
    {
        private readonly RapidApiConfiguration _rapidApiConfiguration;
        private readonly HttpClient _httpClient;

        private const string _rapidApiKeyHeaderName = "x-rapidapi-key";

        public RapidServiceClient(RapidApiConfiguration rapidApiConfiguration)
        {
            _rapidApiConfiguration = rapidApiConfiguration;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add(_rapidApiKeyHeaderName, rapidApiConfiguration.ApiKey);
        }

        public async Task<TResponse> GetAsync<TResponse>(string route) where TResponse : class
        {
            var uri = $"{_rapidApiConfiguration.BaseUrlRoute}/{route}";
            var response = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
            {
                throw response.ToException();
            }

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if(string.IsNullOrWhiteSpace(responseContent))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<TResponse>(responseContent);

        }
        
    }
}

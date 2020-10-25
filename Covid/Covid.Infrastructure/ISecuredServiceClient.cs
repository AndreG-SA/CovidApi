using System.Threading.Tasks;

namespace Covid.Infrastructure
{
    /// <summary>
    /// Handle HTTP request
    /// This can be reused to make different get requests.
    /// Can be extended to handle posts etc
    /// </summary>
    public interface ISecuredServiceClient
    {
        public Task<TResponse> GetAsync<TResponse>(string route) where TResponse : class;
    }
}

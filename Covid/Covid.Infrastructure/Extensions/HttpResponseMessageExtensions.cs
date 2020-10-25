using Covid.Infrastructure.Exceptions;

namespace System.Net.Http
{
    public static class HttpResponseMessageExtensions
    {
        public static ServiceCallException ToException(this HttpResponseMessage httpResponse)
        {
            var responseMessage = httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            if(string.IsNullOrWhiteSpace(responseMessage))
            {
                responseMessage = "Service call failed";
            }
            return new ServiceCallException((int)httpResponse.StatusCode, responseMessage);
        }
    }
}

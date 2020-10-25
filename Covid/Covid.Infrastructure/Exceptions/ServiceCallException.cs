using System;

namespace Covid.Infrastructure.Exceptions
{
    public class ServiceCallException : InvalidOperationException
    {
        public int HttpCode { get; }
        public ServiceCallException(int httpCode, string message) : base(message)
        {
            HttpCode = httpCode;
        }
    }
}

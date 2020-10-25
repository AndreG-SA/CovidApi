using System;

namespace Covid
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

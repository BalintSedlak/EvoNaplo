using System.Net;

namespace EvoNaplo.Common.Exceptions
{
    public class ServiceException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }
        public string Message { get; private set; }

        public ServiceException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ServiceException(HttpStatusCode httpStatusCode, string message, Exception inner) : base(message, inner)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}

using System.Net;

namespace EvoNaplo.Infrastructure.Exceptions
{
    public static class HttpStatusCodeExtension
    {
        public static int ConvertToInt(this HttpStatusCode httpStatusCode)
        {
            return ((int)httpStatusCode);
        }
    }
}

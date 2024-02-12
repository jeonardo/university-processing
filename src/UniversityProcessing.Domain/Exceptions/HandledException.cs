using System.Net;

namespace UniversityProcessing.Domain.Exceptions
{
    public class HandledException(HttpStatusCode statusCode, string message) : Exception(message)
    {
        public HttpStatusCode StatusCode { get; init; } = statusCode;
    }
}

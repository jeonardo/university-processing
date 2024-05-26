using System.Net;

namespace UniversityProcessing.GenericSubdomain.Middlewares.Contracts;

/// <summary>
///     Use HandledException when you need manually stop method execution
/// </summary>
/// <param name="statusCode"></param>
/// <param name="message"></param>
public class HandledException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; init; } = statusCode;
}
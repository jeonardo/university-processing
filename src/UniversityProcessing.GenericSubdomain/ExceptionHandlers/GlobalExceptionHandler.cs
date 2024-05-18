using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using UniversityProcessing.GenericSubdomain.ExceptionHandlers.Contracts;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.GenericSubdomain.ExceptionHandlers;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = exception switch
        {
            HandledException handledException => (int)handledException.StatusCode,
            ArgumentException => StatusCodes.Status400BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(new FailResponseDto(exception.Message), cancellationToken);

        return true;
    }
}
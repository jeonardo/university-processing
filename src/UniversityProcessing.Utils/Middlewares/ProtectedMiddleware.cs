using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using UniversityProcessing.Utils.Http;
using UniversityProcessing.Utils.Middlewares.Contracts;

namespace UniversityProcessing.Utils.Middlewares;

public sealed class ProtectedMiddleware(RequestDelegate next)
{
    private const string CORRELATION_ID_HEADER = "X-Correlation-Id";

    public async Task InvokeAsync(HttpContext httpContext, IHttpContextCorrelationId httpContextCorrelationId)
    {
        var correlationId = GetCorrelationId(httpContext, httpContextCorrelationId);
        AddCorrelationIdHeaderToResponse(httpContext, correlationId);

        try
        {
            await next(httpContext);
        }
        catch (Exception e)
        {
            httpContext.Response.StatusCode = e switch
            {
                HandledException handledException => (int)handledException.StatusCode,
                ArgumentException or ValidationException => StatusCodes.Status400BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(new FailResponseDto(e.Message), httpContext.RequestAborted);
        }
    }

    private static StringValues GetCorrelationId(HttpContext context, IHttpContextCorrelationId httpContextCorrelationId)
    {
        if (!context.Request.Headers.TryGetValue(CORRELATION_ID_HEADER, out var correlationId))
        {
            return httpContextCorrelationId.GetAsString();
        }

        httpContextCorrelationId.Set(correlationId!);
        return correlationId;
    }

    private static void AddCorrelationIdHeaderToResponse(HttpContext context, StringValues correlationId)
    {
        context.Response.OnStarting(
            () =>
            {
                if (context.Response.Headers.ContainsKey(CORRELATION_ID_HEADER))
                {
                    context.Response.Headers[CORRELATION_ID_HEADER] = new[] { correlationId.ToString() };
                    return Task.CompletedTask;
                }

                context.Response.Headers.Append(CORRELATION_ID_HEADER, new[] { correlationId.ToString() });
                return Task.CompletedTask;
            });
    }
}

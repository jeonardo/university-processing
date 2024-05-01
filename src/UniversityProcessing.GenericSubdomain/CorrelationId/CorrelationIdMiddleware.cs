using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using UniversityProcessing.GenericSubdomain.CorrelationId.Contracts;

namespace UniversityProcessing.GenericSubdomain.CorrelationId;

public sealed class CorrelationIdMiddleware(RequestDelegate next)
{
    private const string CORRELATION_ID_HEADER = "X-Correlation-Id";

    public async Task InvokeAsync(HttpContext context, IHttpContextCorrelationId httpContextCorrelationId)
    {
        var correlationId = GetCorrelationId(context, httpContextCorrelationId);
        AddCorrelationIdHeaderToResponse(context, correlationId);
        await next(context);
    }

    private static StringValues GetCorrelationId(HttpContext context, IHttpContextCorrelationId httpContextCorrelationId)
    {
        if (!context.Request.Headers.TryGetValue(CORRELATION_ID_HEADER, out var correlationId))
        {
            return httpContextCorrelationId.GetAsString();
        }

        Guard.Against.Null(correlationId);
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
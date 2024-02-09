using Ardalis.GuardClauses;
using Microsoft.Extensions.Primitives;
using UniversityProcessing.API.Configurations;

namespace UniversityProcessing.API.Middleware
{
    public class CorrelationIdMiddleware(RequestDelegate next)
    {
        private const string _correlationIdHeader = "X-Correlation-Id";

        public async Task InvokeAsync(HttpContext context, IHttpContextCorrelationId httpContextCorrelationId)
        {
            var correlationId = GetCorrelationId(context, httpContextCorrelationId);
            AddCorrelationIdHeaderToResponse(context, correlationId);
            await next(context);
        }

        private static StringValues GetCorrelationId(HttpContext context, IHttpContextCorrelationId httpContextCorrelationId)
        {
            if (!context.Request.Headers.TryGetValue(_correlationIdHeader, out var correlationId))
                return httpContextCorrelationId.Value.ToString();

            Guard.Against.Null(correlationId);
            httpContextCorrelationId.Set(correlationId!);
            return correlationId;
        }

        private static void AddCorrelationIdHeaderToResponse(HttpContext context, StringValues correlationId)
        {
            context.Response.OnStarting(() =>
            {
                if (context.Response.Headers.ContainsKey(_correlationIdHeader))
                {
                    context.Response.Headers[_correlationIdHeader] = new[] { correlationId.ToString() };
                    return Task.CompletedTask;
                }

                context.Response.Headers.Append(_correlationIdHeader, new[] { correlationId.ToString() });
                return Task.CompletedTask;
            });
        }
    }
}

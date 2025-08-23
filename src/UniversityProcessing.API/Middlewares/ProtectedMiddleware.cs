using System.Net;
using FluentValidation;
using Microsoft.Extensions.Primitives;
using UniversityProcessing.API.Endpoints.Common;
using UniversityProcessing.API.Middlewares.Contracts;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Http;

namespace UniversityProcessing.API.Middlewares;

public sealed class ProtectedMiddleware(RequestDelegate next)
{
    private const string CORRELATION_ID_HEADER = "X-Correlation-Id";

    public async Task InvokeAsync(HttpContext httpContext, IHttpContextCorrelationId httpContextCorrelationId)
    {
        //check when user is authenticated really
        var correlationId = GetCorrelationId(httpContext, httpContextCorrelationId);
        AddCorrelationIdHeaderToResponse(httpContext, correlationId);

        try
        {
            if (httpContext.User.Identity is not null && httpContext.User.Identity.IsAuthenticated)
            {
                var authTokenClaims = httpContext.User.GetAuthorizationTokenClaims();

                if (!authTokenClaims.Approved || authTokenClaims.Blocked)
                {
                    throw new AccessDeniedException("Access denied");
                }
            }

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

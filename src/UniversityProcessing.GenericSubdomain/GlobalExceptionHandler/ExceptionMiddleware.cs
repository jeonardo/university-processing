using System.Net;
using Microsoft.AspNetCore.Http;
using UniversityProcessing.GenericSubdomain.CorrelationId.Contracts;
using UniversityProcessing.GenericSubdomain.GlobalExceptionHandler.Contracts;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.GenericSubdomain.GlobalExceptionHandler;

public sealed class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext, IHttpContextCorrelationId httpContextCorrelationId)
    {
        try
        {
            await next(httpContext);
        }
        catch (HandledException handledEx)
        {
            await HandleExceptionAsync(httpContext, handledEx)
                .ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex)
                .ConfigureAwait(false);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        HandledException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)exception.StatusCode;
        await context.Response.WriteAsJsonAsync(new FailResponse(exception.Message));
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsJsonAsync(new FailResponse(exception.Message));
    }
}
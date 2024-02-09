using System.Net;
using UniversityProcessing.API.Configurations;
using UniversityProcessing.Domain.Exceptions;

namespace UniversityProcessing.API.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, IHttpContextCorrelationId httpContextCorrelationId)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (HandledException handledEx)
            {
                await HandleExceptionAsync(httpContext, ex, httpContextCorrelationId.Value);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, httpContextCorrelationId.Value);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, HandledException exception, Guid correlationId)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new BadResponse(correlationId, context.Response.StatusCode, exception.Message).ToString());
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception, Guid correlationId)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new BadResponse(correlationId, context.Response.StatusCode, exception.Message).ToString());
        }
    }

}

using System.Net;
using System.Text.Json;
using UniversityProcessing.API.Configurations;
using UniversityProcessing.Domain.API;
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
                await HandleExceptionAsync(httpContext,
                                           handledEx,
                                           httpContextCorrelationId.Value).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext,
                                           ex,
                                           httpContextCorrelationId.Value).ConfigureAwait(false);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context,
                                                       HandledException exception,
                                                       Guid correlationId)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.StatusCode;
            await context.Response.WriteAsJsonAsync(new BadResponse(correlationId,
                                                                    context.Response.StatusCode,
                                                                    exception.Message));
        }

        private static async Task HandleExceptionAsync(HttpContext context,
                                                       Exception exception,
                                                       Guid correlationId)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new BadResponse(correlationId,
                                                                    context.Response.StatusCode,
                                                                    exception.Message));
        }
    }

}

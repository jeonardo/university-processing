using UniversityProcessing.API.Configurations;
using UniversityProcessing.API.Middleware;

namespace UniversityProcessing.API.Extensions
{
    public static class ProgramExtensions
    {
        public static IServiceCollection AddCorrelationIdGeneratorService(this IServiceCollection services)
        {
            services.AddScoped<IHttpContextCorrelationId, HttpContextCorrelationId>();
            return services;
        }

        public static IApplicationBuilder UseCorrelationIdMiddleware(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<CorrelationIdMiddleware>();
    }
}

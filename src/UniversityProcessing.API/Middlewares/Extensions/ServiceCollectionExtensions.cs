using UniversityProcessing.API.Middlewares.Contracts;

namespace UniversityProcessing.API.Middlewares.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdGeneratorService(this IServiceCollection services)
    {
        services.AddScoped<IHttpContextCorrelationId, HttpContextCorrelationId>();
        return services;
    }
}

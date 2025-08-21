using Microsoft.Extensions.DependencyInjection;
using UniversityProcessing.Utils.Middlewares.Contracts;

namespace UniversityProcessing.Utils.Middlewares.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdGeneratorService(this IServiceCollection services)
    {
        services.AddScoped<IHttpContextCorrelationId, HttpContextCorrelationId>();
        return services;
    }
}

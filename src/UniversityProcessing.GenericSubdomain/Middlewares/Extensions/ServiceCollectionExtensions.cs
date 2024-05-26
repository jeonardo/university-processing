using Microsoft.Extensions.DependencyInjection;
using UniversityProcessing.GenericSubdomain.Middlewares.Contracts;

namespace UniversityProcessing.GenericSubdomain.Middlewares.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdGeneratorService(this IServiceCollection services)
    {
        services.AddScoped<IHttpContextCorrelationId, HttpContextCorrelationId>();
        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;
using UniversityProcessing.GenericSubdomain.CorrelationId.Contracts;

namespace UniversityProcessing.GenericSubdomain.CorrelationId.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdGeneratorService(this IServiceCollection services)
    {
        services.AddScoped<IHttpContextCorrelationId, HttpContextCorrelationId>();
        return services;
    }
}
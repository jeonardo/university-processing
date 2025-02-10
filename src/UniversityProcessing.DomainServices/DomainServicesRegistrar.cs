using Ardalis.SharedKernel;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace UniversityProcessing.DomainServices;

public static class DomainServicesRegistrar
{
    public static void Configure(WebApplicationBuilder builder)
    {
        builder.Services.RegisterRequestHandlers();
    }

    private static IServiceCollection RegisterRequestHandlers(this IServiceCollection services)
    {
        return services
            .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>()
            .AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DomainServicesRegistrar).Assembly))
            .AddValidatorsFromAssembly(typeof(DomainServicesRegistrar).Assembly);
    }
}

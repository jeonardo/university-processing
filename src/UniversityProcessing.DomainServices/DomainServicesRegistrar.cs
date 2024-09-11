﻿using Ardalis.SharedKernel;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityProcessing.DomainServices.Core;

namespace UniversityProcessing.DomainServices;

public static class DomainServicesRegistrar
{
    public static void Configure(IConfiguration configuration, IServiceCollection services)
    {
        services.RegisterRequestHandlers();

        services.AddSingleton<ITokenService, TokenService>();
    }

    private static IServiceCollection RegisterRequestHandlers(this IServiceCollection services)
    {
        return services
            .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>()
            .AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DomainServicesRegistrar).Assembly))
            .AddValidatorsFromAssembly(typeof(DomainServicesRegistrar).Assembly);
    }
}

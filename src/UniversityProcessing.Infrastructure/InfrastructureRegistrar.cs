using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityProcessing.Infrastructure.Base;
using UniversityProcessing.Infrastructure.Queries;
using UniversityProcessing.Infrastructure.Seeds;
using UniversityProcessing.Repository.Queries;

namespace UniversityProcessing.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IConfiguration configuration, IServiceCollection services)
    {
        AddDbContext(configuration, services);
        AddRepositories(services);

        services.AddScoped<UniversitySeed>();
    }

    private static void AddDbContext(IConfiguration configuration, IServiceCollection services)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                    options.UseSqlite("Data Source=ApplicationDbContext.db")
                        .UseSnakeCaseNamingConvention());
            return;
        }

        services.AddDbContext<ApplicationDbContext>(
            options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention());
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped<IUniversityQueries, UniversityQueries>();
    }
}
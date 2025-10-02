using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Infrastructure.Options;
using UniversityProcessing.Infrastructure.Repositories;
using UniversityProcessing.Infrastructure.Seeds;
using UniversityProcessing.Utils.Configuration;

namespace UniversityProcessing.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(WebApplicationBuilder builder)
    {
        RegisterSettings(builder);

        AddDbContext(builder);
        AddIdentity(builder);
        AddRepositories(builder);

        builder.Services.AddTransient<UniversitySeed>();
    }

    private static void RegisterSettings(this WebApplicationBuilder builder)
    {
        builder.AddSettingsWithValidateOnStart<DatabaseSettings>();
        builder.AddSettingsWithValidateOnStart<IdentitySettings>();
    }

    private static void AddDbContext(this WebApplicationBuilder builder)
    {
        var settings = builder.Configuration.GetSettings<DatabaseSettings>();

        var useSqlite = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        if (useSqlite)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                    options
                        .UseSqlite(settings.SqliteConnectionString)
                        .UseSnakeCaseNamingConvention());
        }
        else
        {
            builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                    options
                        .UseSqlServer(settings.ConnectionString)
                        .UseSnakeCaseNamingConvention());
        }
    }

    private static void AddIdentity(this WebApplicationBuilder builder)
    {
        var settings = builder.Configuration.GetSettings<IdentitySettings>();

        builder.Services
            .AddIdentity<User, UserRole>(
                x =>
                {
                    x.Password.RequireUppercase = settings.RequireUppercase;
                    x.Password.RequireLowercase = settings.RequireLowercase;
                    x.Password.RequiredLength = settings.RequiredLength;
                    x.Password.RequireNonAlphanumeric = settings.RequireNonAlphanumeric;
                    x.Password.RequireDigit = settings.RequireDigit;
                })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }

    private static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
        builder.Services.AddScoped(typeof(IEfReadRepository<>), typeof(EfRepository<>));
    }
}

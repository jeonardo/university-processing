using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using UniversityProcessing.API.Options;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices;
using UniversityProcessing.GenericSubdomain.Configuration;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Middlewares.Extensions;
using UniversityProcessing.GenericSubdomain.Swagger;
using UniversityProcessing.Infrastructure;
using UniversityProcessing.Infrastructure.Seeds;

namespace UniversityProcessing.API;

public static partial class Program
{
    private const string APPLICATION_CORS_POLICY = nameof(APPLICATION_CORS_POLICY);

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAppSwagger();
        builder.Services.AddCorrelationIdGeneratorService();
        builder.Services.AddHttpContextAccessor();

        AddSerilog(builder);
        AddIdentity(builder.Services);
        AddAuthentication(builder.Services, builder.Configuration);

        InfrastructureRegistrar.Configure(builder.Configuration, builder.Services);
        DomainServicesRegistrar.Configure(builder.Configuration, builder.Services);

        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        builder.AddEndpoints(Assembly.GetExecutingAssembly());
        builder.AddApplicationCors();

        var app = builder.Build();

        app.MapEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.UseAppSwagger();
            app.MigrateDb();
        }

        app.UseProtectedMiddleware();
        app.UseSerilogRequestLogging();

        app.UseCors(APPLICATION_CORS_POLICY);
        app.UseHttpsRedirection();

        app.UseFileServer();
        app.MapFallbackToFile("/index.html");

        app.UseAuthentication();
        app.UseAuthorization();

        await app.RunAsync();
    }

    private static WebApplication MigrateDb(this WebApplication app)
    {
        using var serviceScope = app.Services
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        logger.LogInformation("Database prepearing");

        try
        {
            if (!app.Environment.IsDevelopment())
            {
                for (var i = 0; i < 15; i++)
                {
                    if (dbContext.Database.CanConnect())
                    {
                        break;
                    }

                    logger.LogInformation("Database not ready yet; waiting...");
                    Thread.Sleep(5000);

                    if (i is 14)
                    {
                        throw new Exception("Database connection lost!");
                    }
                }
            }

            logger.LogInformation("Migrating database...");

            dbContext.Database.Migrate();

            if (app.Environment.IsDevelopment())
            {
                serviceScope.ServiceProvider.GetRequiredService<UniversitySeed>().Seed().GetAwaiter().GetResult();
            }

            logger.LogInformation("Database migrated successfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database");
            throw new ApplicationException(ex.Message);
        }

        app.Logger.LogInformation("Launching UniversityProcessing.API...");
        return app;
    }

    private static void AddApplicationCors(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddOptionsWithValidateOnStart<CorsOptions>()
            .Bind(builder.Configuration.GetSection(nameof(CorsOptions)));

        var allowedOrigins = builder.Configuration
            .GetOptions<CorsOptions>()
            .GetAllowedOrigins();

        builder.Services.AddCors(
            options =>
            {
                options.AddPolicy(
                    APPLICATION_CORS_POLICY,
                    policyBuilder =>
                    {
                        policyBuilder
                            .WithOrigins(allowedOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowedToAllowWildcardSubdomains();
                    });
            });
    }

    private static void AddSerilog(WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .WriteTo.Console()

            //TODO .WriteTo.File(Path.Combine("Logs", "log.txt"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.Host.UseSerilog(logger);
    }

    private static void AddIdentity(IServiceCollection services)
    {
        services
            .AddIdentity<User, UserRole>(
                x =>
                {
                    x.Password.RequireUppercase = false;
                    x.Password.RequireLowercase = false;
                    x.Password.RequiredLength = 4;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequireDigit = false;
                })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptionsWithValidateOnStart<AuthOptions>()
            .Bind(configuration.GetSection(nameof(AuthOptions)));

        services.AddSingleton<ITokenService, TokenService>();

        var authOptions = configuration.GetOptions<AuthOptions>();

        services
            .AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme =
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = authOptions.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(authOptions.AccessKey)),
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (string.IsNullOrWhiteSpace(context.Request.Headers.Authorization))
                            {
                                context.Token = context.Request.Cookies["AccessToken"];
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

        services.AddAuthorization(
            options =>
            {
                foreach (var policy in Policies.PermissionsByPolicy)
                {
                    options.AddPolicy(
                        policy.Key,
                        configurePolicy =>
                        {
                            configurePolicy.RequireClaim(
                                policy.Value,
                                "true");
                        });
                }
            });

        services.AddAuthorizationBuilder();
    }
}

// REMARK: Required for functional and integration tests to work.
public static partial class Program;

using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using UniversityProcessing.API.Options;
using UniversityProcessing.API.Services.Auth;
using UniversityProcessing.API.Services.Registration;
using UniversityProcessing.GenericSubdomain.Configuration;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Middlewares.Extensions;
using UniversityProcessing.GenericSubdomain.Swagger;
using UniversityProcessing.Infrastructure;
using UniversityProcessing.Infrastructure.Extensions;

namespace UniversityProcessing.API;

public static partial class Program
{
    private const string APPLICATION_CORS_POLICY = nameof(APPLICATION_CORS_POLICY);

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.RegisterSettings();

        builder.Services.AddAppSwagger();
        builder.Services.AddCorrelationIdGeneratorService();
        builder.Services.AddHttpContextAccessor();

        InfrastructureRegistrar.Configure(builder);

        builder.AddSerilog();
        builder.AddAuthentication();
        builder.Services.AddScoped<IRegistrationService, RegistrationService>();

        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        builder.AddEndpoints(Assembly.GetExecutingAssembly());
        builder.AddApplicationCors();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseAppSwagger();
            app.MigrateDb();
        }

        app.UseProtectedMiddleware();
        app.UseSerilogRequestLogging();

        app.UseCors(APPLICATION_CORS_POLICY);
        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseFileServer();
        app.MapFallbackToFile("/index.html");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapEndpoints();

        await app.RunAsync();
    }

    private static void RegisterSettings(this WebApplicationBuilder builder)
    {
        builder.AddSettingsWithValidateOnStart<AuthSettings>();
        builder.AddSettingsWithValidateOnStart<CorsSettings>();
        builder.AddSettingsWithValidateOnStart<LoggerSettings>();
        builder.AddSettingsWithValidateOnStart<UniversitySettings>();
    }

    private static void AddApplicationCors(this WebApplicationBuilder builder)
    {
        var allowedOrigins = builder.Configuration
            .GetSettings<CorsSettings>()
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

    private static void AddSerilog(this WebApplicationBuilder builder)
    {
        var settings = builder.Configuration.GetSettings<LoggerSettings>();

        var logger = new LoggerConfiguration()
            .ReadFrom.Settings(settings)
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog(logger);
    }

    private static void AddAuthentication(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var settings = builder.Configuration.GetSettings<AuthSettings>();

        services.AddSingleton<ITokenService, TokenService>();

        services.AddControllersWithViews();
        services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = settings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(settings.AccessKey)),
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
                                "true",
                                "True");
                        });
                }
            });

        services.AddAuthorizationBuilder();
    }
}

// REMARK: Required for functional and integration tests to work.
public static partial class Program;

using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices;
using UniversityProcessing.DomainServices.Options;
using UniversityProcessing.GenericSubdomain.Middlewares;
using UniversityProcessing.GenericSubdomain.Middlewares.Extensions;
using UniversityProcessing.Infrastructure;
using UniversityProcessing.Infrastructure.Seeds;

namespace UniversityProcessing.API;

public static partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AddSerilog(builder);
        AddIdentity(builder.Services);
        AddAuthentication(builder.Services, builder.Configuration);
        AddUtilities(builder.Services);

        InfrastructureRegistrar.Configure(builder.Configuration, builder.Services);
        DomainServicesRegistrar.Configure(builder.Configuration, builder.Services);

        builder.Services
            .AddControllers()
            .AddJsonOptions(o => { o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

        builder.Services.AddCors(
            x =>
                x.AddDefaultPolicy(
                    corsPolicyBuilder =>
                        corsPolicyBuilder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()));

        var app = builder.Build();

        app.UseProtectedMiddleware();
        app.UseSerilogRequestLogging();

        app.MapControllers();
        app.UseRouting();
        app.UseCors();
        app.UseHttpsRedirection();

        app.UseFileServer();
        app.MapFallbackToFile("/index.html");

        UseAuthentication(app);

        if (app.Environment.IsDevelopment())
        {
            UseSwagger(app);
        }
        else
        {
            app.UseHsts();
        }

        app
            .MigrateDb()
            .Run();
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

    private static void AddUtilities(IServiceCollection services)
    {
        services.AddCorrelationIdGeneratorService();
        services.AddHttpContextAccessor();

        AddSwagger(services);
    }

    private static void AddSerilog(WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .WriteTo.Console()
            .WriteTo.File(Path.Combine("Logs", "log.txt"), rollingInterval: RollingInterval.Day)
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
            .Bind(configuration.GetSection(nameof(AuthOptions)))
            .ValidateDataAnnotations();

        var settings = configuration
                .GetSection(nameof(AuthOptions))
                .Get<AuthOptions>()
            ?? throw new ApplicationException($"{nameof(AuthOptions)} must be set");

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
                        ValidIssuer = settings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.AccessKey)),
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

        services.AddAuthorizationBuilder();
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "University project API", Version = "v1" });
                c.EnableAnnotations();
                c.SchemaFilter<CorrelationIdSchemaFilter>();

                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = """
                                      JWT Authorization header using the Bearer scheme. \r\n\r\n
                                      Enter 'Bearer' [space] and then your token in the text input below.
                                      \r\n\r\nExample: 'Bearer 12345'
                                      """,
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                    });
            });
    }

    private static void UseSwagger(IApplicationBuilder app)
    {
        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "University project API V1"); });
    }

    private static void UseAuthentication(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}

/// <summary>
///     For tests
/// </summary>
public static partial class Program
{
}

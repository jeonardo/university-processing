using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using UniversityProcessing.API.Extensions;
using UniversityProcessing.API.Filters;
using UniversityProcessing.API.Middleware;
using UniversityProcessing.API.Utils;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.DTOs;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Infrastructure;
using UniversityProcessing.Infrastructure.Repositories;
using UniversityProcessing.Infrastructure.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog
Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();

builder.Services.AddCorrelationIdGeneratorService();

var authOptions = new AuthOptions();
builder.Configuration.GetSection("AuthOptions").Bind(authOptions);
builder.Services.AddSingleton(authOptions);

if (EnvironmentUtil.IsDevelopment)
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite("Data Source=ApplicationDbContext.db")
               .UseSnakeCaseNamingConvention());
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
               .UseSnakeCaseNamingConvention());
}

builder.Services
    .AddIdentity<UserEntity, UserRoleEntity>(x =>
    {
        x.Password.RequireUppercase = false;
        x.Password.RequireLowercase = false;
        x.Password.RequiredLength = 4;
        x.Password.RequireNonAlphanumeric = false;
        x.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = authOptions.ValidateIssuer,
    ValidateAudience = authOptions.ValidateAudience,
    ValidateIssuerSigningKey = authOptions.ValidateIssuerSigningKey,
    ValidIssuer = authOptions.ValidIssuer,
    ValidAudience = authOptions.ValidAudience,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Key))
};
builder.Services.AddSingleton(tokenValidationParameters);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = tokenValidationParameters;
    });

builder.Services.AddAuthorizationBuilder();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<UniversitySeed>();

builder.Services.AddCors(x =>
    x.AddDefaultPolicy(x =>
        x.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod())
);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
    c.SchemaFilter<CustomSchemaFilters>();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
            });
});

var app = builder.Build();

// Add Serilog middleware
app.UseSerilogRequestLogging();

app.UseCorrelationIdMiddleware();
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.MapControllers();

app.MapFallbackToFile("/index.html");

using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database;

logger.LogInformation("Prepearing database");

try
{
    if (!EnvironmentUtil.IsDevelopment)
        for (var i = 0; i < 15; i++)
        {
            if (db.CanConnect())
                break;

            logger.LogInformation("Database not ready yet; waiting...");
            Thread.Sleep(5000);

            if (i is 14)
                throw new Exception("Database connection lost!");
        }

    logger.LogInformation("Migrating database...");

    serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
    serviceScope.ServiceProvider.GetRequiredService<UniversitySeed>().Seed();

    logger.LogInformation("Database migrated successfully.");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while migrating the database.");
}

app.Logger.LogInformation("Launching UniversityProcessing.API...");

app.Run();

public partial class Program { }
using AutoMapper.Internal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UniversityProcessing.API.Utils;
using UniversityProcessing.Infrastructure;
using UniversityProcessing.Infrastructure.Repositories;
using UniversityProcessing.Infrastructure.Seeds;
using UniversityProcessing.Shared.Automapper;
using UniversityProcessing.Shared.DTOs;
using UniversityProcessing.Shared.Entities;

var builder = WebApplication.CreateBuilder(args);

var authOptions = new AuthOptions();
builder.Configuration.GetSection("AuthOptions").Bind(authOptions);
builder.Services.AddSingleton(authOptions);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.Internal().MethodMappingEnabled = false, typeof(AutoMapperProfile).Assembly);

if (EnvironmentUtil.IsDevelopment)
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("ApplicationDb")
               .UseSnakeCaseNamingConvention());
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
               .UseSnakeCaseNamingConvention());
}

builder.Services
    .AddIdentityCore<UserEntity>(x =>
    {
        x.Password.RequireUppercase = false;
        x.Password.RequireLowercase = false;
        x.Password.RequiredLength = 4;
        x.Password.RequireNonAlphanumeric = false;
        x.Password.RequireDigit = false;
    })
    .AddRoles<UserRoleEntity>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

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

builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<UniversitySeed>();

builder.Services.AddCors(x =>
    x.AddDefaultPolicy(x =>
        x.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod())
);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

//app.MapIdentityApi<UserEntity>();
app.MapControllers();

app.MapFallbackToFile("/index.html");

using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database;

logger.LogInformation("Migrating database...");

while (!db.CanConnect())
{
    logger.LogInformation("Database not ready yet; waiting...");
    Thread.Sleep(1000);
}

try
{
    serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
    serviceScope.ServiceProvider.GetRequiredService<UniversitySeed>().Seed();

    logger.LogInformation("Database migrated successfully.");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while migrating the database.");
}

app.Run();

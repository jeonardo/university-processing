using AutoMapper.Internal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UniversityProcessing.API.Automapper;
using UniversityProcessing.API.Domain.DTOs;
using UniversityProcessing.API.Infrastructure;
using UniversityProcessing.API.Infrastructure.Entities;
using UniversityProcessing.API.Infrastructure.Repositories;
using UniversityProcessing.API.Infrastructure.Seeds;
using UniversityProcessing.API.Interfaces.Infrastructure;

namespace UniversityProcessing.API
{
    public static class ProgramExtentions
    {
        public static void AddCustomServices(this WebApplicationBuilder builder)
        {
            var authOptions = new AuthOptions();
            builder.Configuration.Bind(authOptions);
            builder.Services.AddSingleton(authOptions);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(cfg => cfg.Internal().MethodMappingEnabled = false, typeof(AutomapperProfile).Assembly);

            // Added configuration for PostgreSQL
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration
                .GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention());

            builder.Services
                .AddIdentityCore<UserEntity>()
                .AddRoles<UserRoleEntity>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = authOptions.ValidateIssuer,
                        ValidateAudience = authOptions.ValidateAudience,
                        ValidateIssuerSigningKey = authOptions.ValidateIssuerSigningKey,
                        ValidIssuer = authOptions.ValidIssuer,
                        ValidAudience = authOptions.ValidAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Key))
                    };
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
        }

        public static void UseCustomServices(this WebApplication app)
        {
            app.UseCors(options => options
                              .AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapIdentityApi<UserEntity>();
            app.MapControllers();

            app.MapFallbackToFile("/index.html");
        }

        public static void MigrateDb(this WebApplication app)
        {
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
        }
    }
}

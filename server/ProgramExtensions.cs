using AutoMapper.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Automapper;
using UniversityProcessing.API.Infrastructure;
using UniversityProcessing.API.Infrastructure.Entities;
using UniversityProcessing.API.Interfaces.Infrastructure;

namespace UniversityProcessing.API
{
    public static class ProgramExtentions
    {
        public static void AddCustomServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(cfg => cfg.Internal().MethodMappingEnabled = false, typeof(AutomapperProfile).Assembly);

            // Added configuration for PostgreSQL
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            builder.Services
                .AddIdentityCore<UserEntity>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();

            builder.Services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();

            builder.Services.AddAuthorizationBuilder();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            //app.UseAuthorization();

            app.MapIdentityApi<UserEntity>();
            app.MapControllers();

            app.MapFallbackToFile("/index.html");
        }

        public static async void MigrateDb(this WebApplication app)
        {
            //using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            //var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database;

            //logger.LogInformation("Migrating database...");

            //while (!db.CanConnect())
            //{
            //    logger.LogInformation("Database not ready yet; waiting...");
            //    Thread.Sleep(1000);
            //}

            //try
            //{
            //    serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();

            //    var initList = new List<AddPhoneBookRequest>()
            //    {
            //        new()
            //        {

            //            CompanySize = 1,
            //            Debt = 101,
            //            ContactType = "Public organization",
            //            Name = "OOO Dikidi",
            //            Notes = "",
            //            PhoneNumber = "+375257529876"
            //        },
            //        new()
            //        {

            //            CompanySize = 1,
            //            Debt = 0,
            //            ContactType = "Private organization",
            //            Name = "OOO Dodo pizza",
            //            Notes = "",
            //            PhoneNumber = "+375257529876"
            //        },
            //        new()
            //        {

            //            CompanySize = 1,
            //            Debt = 24,
            //            ContactType = "Private organization",
            //            Name = "OOO Your wishes",
            //            Notes = "",
            //            PhoneNumber = "+375257529876"
            //        },
            //        new()
            //        {

            //            CompanySize = 01,
            //            Debt = 10,
            //            ContactType = "Person",
            //            Name = "Michele",
            //            Notes = "",
            //            PhoneNumber = "+375257529876"
            //        }
            //    };

            //    var rep = serviceScope.ServiceProvider.GetRequiredService<IPhoneBookService>();
            //    await rep.CreateRangeAsync(initList);

            //    logger.LogInformation("Database migrated successfully.");
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, "An error occurred while migrating the database.");
            //}
        }
    }
}

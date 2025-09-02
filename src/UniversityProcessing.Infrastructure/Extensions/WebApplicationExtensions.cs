using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UniversityProcessing.Infrastructure.Seeds;

namespace UniversityProcessing.Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MigrateDb(this WebApplication app)
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

            // TODO
            // dbContext.Database.EnsureDeleted();
            // dbContext.Database.EnsureCreated();

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
}

using Microsoft.OpenApi.Models;
using UniversityProcessing.API.Middlewares;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Swagger;

public static class ServiceCollectionExtensions
{
    public static void AddAppSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            options =>
            {
                options.CustomSchemaIds(NamespaceService.GetDtoSchemaId);

                options.SwaggerDoc("v1", new OpenApiInfo { Title = "University project API", Version = "v1" });
                options.EnableAnnotations();
                options.SchemaFilter<CorrelationIdSchemaFilter>();

                options.AddSecurityDefinition(
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

                options.AddSecurityRequirement(
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

    public static void UseAppSwagger(this IApplicationBuilder app)
    {
        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "University project API V1"); });
    }
}

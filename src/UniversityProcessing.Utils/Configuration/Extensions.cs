using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace UniversityProcessing.Utils.Configuration;

public static class Extensions
{
    public static void AddSettingsWithValidateOnStart<TSettings>(this WebApplicationBuilder builder)
        where TSettings : class
    {
        builder.Services
            .AddOptionsWithValidateOnStart<TSettings>()
            .Bind(builder.Configuration.GetSection(typeof(TSettings).Name))
            .ValidateDataAnnotations();
    }

    public static TSettings GetSettings<TSettings>(this IConfiguration configuration)
        where TSettings : class
    {
        var settingsType = typeof(TSettings);
        var settings = configuration.GetSection(settingsType.Name).Get<TSettings>();

        if (settings is null)
        {
            throw new OptionsValidationException(settingsType.Name, settingsType, new[] { $"{settingsType.Name} is not specified" });
        }

        return settings;
    }
}

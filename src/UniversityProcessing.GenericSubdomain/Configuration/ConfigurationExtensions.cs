using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace UniversityProcessing.GenericSubdomain.Configuration;

public static class ConfigurationExtensions
{
    public static TSettings GetOptions<TSettings>(this IConfiguration configuration)
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

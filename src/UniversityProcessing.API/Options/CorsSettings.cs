using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Configuration;

namespace UniversityProcessing.API.Options;

public sealed class CorsSettings : ISettings
{
    [Required]
    public string AllowedOrigins { get; set; } = string.Empty;

    public string[] GetAllowedOrigins()
    {
        return AllowedOrigins.Split(";");
    }
}

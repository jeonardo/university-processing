using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Options;

public sealed class CorsOptions
{
    [Required]
    public string AllowedOrigins { get; set; } = string.Empty;

    public string[] GetAllowedOrigins()
    {
        return AllowedOrigins.Split(";");
    }
}

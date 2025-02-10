using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Configuration;

namespace UniversityProcessing.API.Options;

public sealed class AuthSettings : ISettings
{
    [Required]
    public string Issuer { get; set; } = string.Empty;

    [Required]
    public string AccessKey { get; set; } = string.Empty;

    [Required]
    public string RefreshKey { get; set; } = string.Empty;

    [Required]
    public int AccessTokenLifetimeInMinutes { get; set; }

    [Required]
    public int RefreshTokenLifetimeInMinutes { get; set; }
}

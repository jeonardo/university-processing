using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Configuration;

namespace UniversityProcessing.API.Options;

public sealed class UniversitySettings : ISettings
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;
}

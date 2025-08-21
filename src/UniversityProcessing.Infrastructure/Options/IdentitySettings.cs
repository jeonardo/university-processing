using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Configuration;

namespace UniversityProcessing.Infrastructure.Options;

public sealed class IdentitySettings : ISettings
{
    public bool RequireUppercase { get; set; }
    public bool RequireLowercase { get; set; }

    [Range(4, int.MaxValue)]
    public int RequiredLength { get; set; }

    public bool RequireNonAlphanumeric { get; set; }
    public bool RequireDigit { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class CreateUniversityRequestDto
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; set; } = string.Empty;
}

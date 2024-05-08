using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityCreateRequestDto
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; set; } = string.Empty;
}
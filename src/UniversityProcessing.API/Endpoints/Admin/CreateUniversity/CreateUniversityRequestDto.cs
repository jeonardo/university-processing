using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.CreateUniversity;

public sealed class CreateUniversityRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;
}

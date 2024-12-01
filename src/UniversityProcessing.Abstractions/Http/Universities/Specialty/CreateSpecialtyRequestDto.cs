using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class CreateSpecialtyRequestDto
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; set; } = string.Empty;

    [Required]
    [StringLength(12, MinimumLength = 12)]
    public string Code { get; set; } = string.Empty;

    public Guid FacultyId { get; set; }
}

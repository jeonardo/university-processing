using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Specialties.Create;

public sealed class CreateSpecialtyRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;

    [Required]
    public string Code { get; set; } = string.Empty;

    [Required]
    public Guid DepartmentId { get; set; }
}

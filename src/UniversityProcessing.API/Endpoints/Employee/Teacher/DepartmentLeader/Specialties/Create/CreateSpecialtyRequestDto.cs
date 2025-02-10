using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.Specialties.Create;

public sealed class CreateSpecialtyRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;

    [Required]
    public string Code { get; set; } = string.Empty;

    public Guid? DepartmentId { get; set; }
}

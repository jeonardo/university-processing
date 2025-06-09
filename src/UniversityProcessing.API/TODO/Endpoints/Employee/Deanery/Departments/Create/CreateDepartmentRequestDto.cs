using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Deanery.Departments.Create;

public sealed class CreateDepartmentRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;

    public Guid? FacultyId { get; set; }
}

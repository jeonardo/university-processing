using System.ComponentModel.DataAnnotations;

namespace StoreTest.TODO.Endpoints.Employee.Deanery.Departments.Create;

public sealed class CreateDepartmentRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;

    [Required]
    public Guid FacultyId { get; set; }
}

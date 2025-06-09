using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Deanery.Departments.Delete;

public sealed class DeleteDepartmentRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

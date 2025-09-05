using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Departments.Delete;

public sealed class DeleteDepartmentRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

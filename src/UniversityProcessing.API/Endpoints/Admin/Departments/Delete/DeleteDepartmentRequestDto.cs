using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.Departments.Delete;

public sealed class DeleteDepartmentRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Departments.SetDepartmentHead;

public sealed class RequestDto
{
    [Required]
    public Guid DepartmentId { get; set; }

    [Required]
    public Guid UserId { get; set; }
}

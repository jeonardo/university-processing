using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Departments.SetDepartmentHead;

public sealed class RequestDto
{
    [Required]
    public long DepartmentId { get; set; }

    [Required]
    public long UserId { get; set; }
}

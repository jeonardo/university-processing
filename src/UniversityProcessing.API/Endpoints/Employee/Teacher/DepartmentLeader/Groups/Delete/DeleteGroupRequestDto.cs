using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Delete;

public sealed class DeleteGroupRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Create;

public sealed class CreateGroupResponseDto(Guid id)
{
    [Required]
    public Guid Id { get; set; } = id;
}

using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Create;

public sealed class CreateGroupResponseDto(Guid id)
{
    [Required]
    public Guid Id { get; set; } = id;
}

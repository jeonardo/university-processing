using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Create;

public sealed record CreateDiplomaProcessRequestDto
{
    [Required]
    public Guid PeriodId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
}

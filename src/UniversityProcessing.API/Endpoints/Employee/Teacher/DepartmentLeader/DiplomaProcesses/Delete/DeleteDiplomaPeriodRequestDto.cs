using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Delete;

public sealed class DeleteDiplomaPeriodRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

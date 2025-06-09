using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Delete;

public sealed class DeleteDiplomaPeriodRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

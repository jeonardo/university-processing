using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Remove;

public sealed class RemoveUsersRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public Guid[] UserIds { get; set; } = [];
}

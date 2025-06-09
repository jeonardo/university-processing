using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.TODO.Endpoints.Contracts;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Get;

public sealed class GetDiplomaPeriodUsersRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public UserRoleTypeDto RoleType { get; set; }
}

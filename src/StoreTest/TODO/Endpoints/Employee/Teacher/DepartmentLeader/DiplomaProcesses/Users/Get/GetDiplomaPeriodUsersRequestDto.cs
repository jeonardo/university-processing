using System.ComponentModel.DataAnnotations;

namespace StoreTest.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Get;

public sealed class GetDiplomaPeriodUsersRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public UserRoleTypeDto RoleType { get; set; }
}

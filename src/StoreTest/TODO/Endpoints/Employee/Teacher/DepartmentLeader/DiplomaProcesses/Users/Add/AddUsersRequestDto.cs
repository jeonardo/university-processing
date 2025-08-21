using System.ComponentModel.DataAnnotations;

namespace StoreTest.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Add;

public sealed class AddUsersRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public Guid[] UserIds { get; set; } = [];
}

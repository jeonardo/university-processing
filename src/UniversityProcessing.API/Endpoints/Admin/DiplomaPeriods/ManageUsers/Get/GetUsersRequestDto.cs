using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageUsers.Get;

public sealed class GetUsersRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public UserRoleDto Role { get; set; }
}

using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Users.Get;

public sealed class GetDiplomaPeriodUsersRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public UserRoleTypeDto RoleType { get; set; }
}

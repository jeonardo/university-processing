using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Users.Remove;

public sealed class RemoveUsersRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public Guid[] UserIds { get; set; } = [];
}

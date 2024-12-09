using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Users.Add;

public sealed class AddUsersRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public Guid[] UserIds { get; set; } = [];
}

using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Users.Add;

public sealed class AddUserRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public Guid[] UserIds { get; set; } = [];
}

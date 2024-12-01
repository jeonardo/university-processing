using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.Users.UpdateApproval;

public sealed class UpdateApprovalRequestDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public bool IsApproved { get; set; }
}

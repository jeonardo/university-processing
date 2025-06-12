using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Auth.UpdateVerification;

public sealed class UpdateVerificationRequestDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public bool IsApproved { get; set; }
}

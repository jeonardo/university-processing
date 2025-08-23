using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register;

public sealed class RegisterResponseDto(Guid userId)
{
    [Required]
    public Guid UserId { get; set; } = userId;
}

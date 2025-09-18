using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.Register;

public sealed class BaseResponseDto(Guid userId)
{
    [Required]
    public Guid UserId { get; set; } = userId;
}

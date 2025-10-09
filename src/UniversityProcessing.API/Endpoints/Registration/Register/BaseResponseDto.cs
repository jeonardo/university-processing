using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.Register;

public sealed class BaseResponseDto(long userId)
{
    [Required]
    public long UserId { get; set; } = userId;
}

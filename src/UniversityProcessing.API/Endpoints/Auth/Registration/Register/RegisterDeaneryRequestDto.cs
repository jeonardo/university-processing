using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register;

public sealed class RegisterDeaneryRequestDto : BaseRegisterRequestDto
{
    [Required]
    public Guid UniversityPositionId { get; set; }

    [Required]
    public Guid FacultyId { get; set; }
}

using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Auth.Registration.Common.Forms;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Deanery;

public sealed class RegisterDeaneryRequestDto : BaseRegisterRequestDto, IDeaneryRegistrationForm
{
    [Required]
    public Guid UniversityPositionId { get; set; }

    [Required]
    public Guid FacultyId { get; set; }
}

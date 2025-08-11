using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Services.Registration.Forms;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register;

public sealed class RegisterStudentRequestDto : BaseRegisterRequestDto
{
    [Required]
    public string GroupNumber { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Auth.Registration.Common.Forms;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Student;

public sealed class RegisterStudentRequestDto : BaseRegisterRequestDto, IStudentRegistrationForm
{
    [Required]
    public string GroupNumber { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Auth.Registration.Common.Forms;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Teacher;

public sealed class RegisterTeacherRequestDto : BaseRegisterRequestDto, ITeacherRegistrationForm
{
    [Required]
    public Guid UniversityPositionId { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }
}

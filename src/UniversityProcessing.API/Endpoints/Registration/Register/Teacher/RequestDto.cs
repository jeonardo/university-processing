using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Registration.Common.Forms;

namespace UniversityProcessing.API.Endpoints.Registration.Register.Teacher;

public sealed class RequestDto : BaseRequestDto, ITeacherRegistrationForm
{
    [Required]
    public long UniversityPositionId { get; set; }

    [Required]
    public long DepartmentId { get; set; }
}

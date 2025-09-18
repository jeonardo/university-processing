using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Registration.Common.Forms;

namespace UniversityProcessing.API.Endpoints.Registration.Register.Student;

public sealed class RequestDto : BaseRequestDto, IStudentRegistrationForm
{
    [Required]
    public string GroupNumber { get; set; } = string.Empty;
}

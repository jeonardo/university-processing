using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Registration.Common.Forms;

namespace UniversityProcessing.API.Endpoints.Registration.Register.Deanery;

public sealed class RequestDto : BaseRequestDto, IDeaneryRegistrationForm
{
    [Required]
    public long UniversityPositionId { get; set; }

    [Required]
    public long FacultyId { get; set; }
}

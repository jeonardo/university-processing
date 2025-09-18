using System.ComponentModel.DataAnnotations;
using UniversityProcessing.API.Endpoints.Registration.Common.Forms;

namespace UniversityProcessing.API.Endpoints.Registration.Register.Deanery;

public sealed class RequestDto : BaseRequestDto, IDeaneryRegistrationForm
{
    [Required]
    public Guid UniversityPositionId { get; set; }

    [Required]
    public Guid FacultyId { get; set; }
}

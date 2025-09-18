using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableDepartments;

public sealed class RequestDto
{
    [Required]
    public Guid FacultyId { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableDepartments;

public sealed class GetAvailableDepartmentsRequestDto
{
    [Required]
    public Guid FacultyId { get; set; }
}

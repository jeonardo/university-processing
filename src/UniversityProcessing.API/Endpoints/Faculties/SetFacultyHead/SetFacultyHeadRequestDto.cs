using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Faculties.SetFacultyHead;

public sealed class SetFacultyHeadRequestDto
{
    [Required]
    public Guid FacultyId { get; set; }

    [Required]
    public Guid UserId { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Faculties.SetFacultyHead;

public sealed class RequestDto
{
    [Required]
    public long FacultyId { get; set; }

    [Required]
    public long UserId { get; set; }
}

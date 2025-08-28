using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Faculties.GetFullDescription;

public sealed class GetFacultyFullDescriptionRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

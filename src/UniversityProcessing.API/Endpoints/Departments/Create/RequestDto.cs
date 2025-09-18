using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Departments.Create;

public sealed class RequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;

    [Required]
    public Guid FacultyId { get; set; }
}

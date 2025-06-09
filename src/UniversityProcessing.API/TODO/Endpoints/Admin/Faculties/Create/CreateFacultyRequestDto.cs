using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Admin.Faculties.Create;

public sealed class CreateFacultyRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;
}

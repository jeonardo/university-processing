using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Faculties.Delete;

public sealed class DeleteFacultyRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

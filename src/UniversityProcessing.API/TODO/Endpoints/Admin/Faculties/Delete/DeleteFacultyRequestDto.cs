using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Admin.Faculties.Delete;

public sealed class DeleteFacultyRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

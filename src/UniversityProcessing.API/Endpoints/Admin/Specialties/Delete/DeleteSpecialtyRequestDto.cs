using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.Specialties.Delete;

public sealed class DeleteSpecialtyRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

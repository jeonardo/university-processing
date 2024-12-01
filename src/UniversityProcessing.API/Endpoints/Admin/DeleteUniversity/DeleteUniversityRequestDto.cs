using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.DeleteUniversity;

public sealed record DeleteUniversityRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

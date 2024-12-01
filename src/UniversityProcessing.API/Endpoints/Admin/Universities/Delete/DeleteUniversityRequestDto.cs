using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.Universities.Delete;

public sealed record DeleteUniversityRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

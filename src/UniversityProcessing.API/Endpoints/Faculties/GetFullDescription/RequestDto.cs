using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Faculties.GetFullDescription;

public sealed class RequestDto
{
    [Required]
    public Guid Id { get; set; }
}

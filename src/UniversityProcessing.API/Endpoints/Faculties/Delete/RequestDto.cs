using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Faculties.Delete;

public sealed class RequestDto
{
    [Required]
    public Guid Id { get; set; }
}

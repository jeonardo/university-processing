using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Faculties.Delete;

public sealed class RequestDto
{
    [Required]
    public long Id { get; set; }
}

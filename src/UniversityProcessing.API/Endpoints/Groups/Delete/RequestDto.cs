using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Groups.Delete;

public sealed class RequestDto
{
    [Required]
    public Guid Id { get; set; }
}

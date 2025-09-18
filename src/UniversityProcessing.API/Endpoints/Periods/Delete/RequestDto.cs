using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Periods.Delete;

public sealed class RequestDto
{
    [Required]
    public Guid Id { get; set; }
}

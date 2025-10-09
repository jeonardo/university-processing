using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Periods.Delete;

public sealed class RequestDto
{
    [Required]
    public long Id { get; set; }
}

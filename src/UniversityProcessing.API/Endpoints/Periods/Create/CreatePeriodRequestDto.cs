using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Periods.Create;

public sealed class CreatePeriodRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime From { get; set; }

    [Required]
    public DateTime To { get; set; }

    public string? Comments { get; set; }
}

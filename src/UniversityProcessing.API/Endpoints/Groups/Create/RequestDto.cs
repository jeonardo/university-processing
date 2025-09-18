using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Groups.Create;

public sealed class RequestDto
{
    [Required]
    public string GroupNumber { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public Guid SpecialtyId { get; set; }

    [Required]
    public Guid PeriodId { get; set; }
}

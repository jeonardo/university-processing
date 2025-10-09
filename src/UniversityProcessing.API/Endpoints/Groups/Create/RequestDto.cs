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
    public long SpecialtyId { get; set; }

    [Required]
    public long PeriodId { get; set; }
}

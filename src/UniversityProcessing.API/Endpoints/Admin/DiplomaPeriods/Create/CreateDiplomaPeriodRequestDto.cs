using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Create;

public sealed record CreateDiplomaPeriodRequestDto
{
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public Guid? FacultyId { get; set; }
}

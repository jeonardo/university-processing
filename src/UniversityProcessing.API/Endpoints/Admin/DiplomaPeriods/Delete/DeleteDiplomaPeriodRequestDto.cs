using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Delete;

public sealed class DeleteDiplomaPeriodRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

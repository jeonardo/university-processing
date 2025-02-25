using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.Periods.Delete;

public sealed class DeletePeriodRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

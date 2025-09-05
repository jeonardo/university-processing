using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Periods.Delete;

public sealed class DeletePeriodRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

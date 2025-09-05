using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Periods.Create;

public sealed class CreatePeriodResponseDto(Guid id)
{
    [Required]
    public Guid Id { get; set; } = id;
}

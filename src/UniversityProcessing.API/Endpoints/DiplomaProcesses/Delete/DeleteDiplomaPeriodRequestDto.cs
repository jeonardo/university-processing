using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Delete;

public sealed class DeleteDiplomaPeriodRequestDto
{
    [Required]
    public Guid Id { get; set; }
}

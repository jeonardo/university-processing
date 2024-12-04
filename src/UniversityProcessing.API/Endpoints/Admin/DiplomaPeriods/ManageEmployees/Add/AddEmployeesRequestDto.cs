using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageEmployees.Add;

public sealed class AddEmployeesRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }

    [Required]
    public Guid[] UserIds { get; set; } = [];
}

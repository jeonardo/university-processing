using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageEmployees.Get;

public sealed class GetEmployeesRequestDto
{
    [Required]
    public Guid DiplomaPeriodId { get; set; }
}

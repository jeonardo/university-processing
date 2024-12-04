namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageEmployees.Get;

public sealed class GetEmployeesResponseDto(IEnumerable<EmployeeDto> list)
{
    public IEnumerable<EmployeeDto> List { get; set; } = list;
}

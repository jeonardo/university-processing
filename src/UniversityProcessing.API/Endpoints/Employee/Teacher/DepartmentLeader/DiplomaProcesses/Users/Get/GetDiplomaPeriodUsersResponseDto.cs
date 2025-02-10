namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Get;

public sealed class GetDiplomaPeriodUsersResponseDto(IEnumerable<DiplomaPeriodUserDto> list)
{
    public IEnumerable<DiplomaPeriodUserDto> List { get; set; } = list;
}

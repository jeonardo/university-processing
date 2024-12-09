namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Users.Get;

public sealed class GetDiplomaPeriodUsersResponseDto(IEnumerable<DiplomaPeriodUserDto> list)
{
    public IEnumerable<DiplomaPeriodUserDto> List { get; set; } = list;
}

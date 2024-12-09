namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.ManageUsers.Get;

public sealed class GetUsersResponseDto(IEnumerable<UserDto> list)
{
    public IEnumerable<UserDto> List { get; set; } = list;
}

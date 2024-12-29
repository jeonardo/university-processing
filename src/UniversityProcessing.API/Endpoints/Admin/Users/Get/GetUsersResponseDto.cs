using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Admin.Users.GetUsers;

public sealed class GetUsersResponseDto(PagedList<UserDto> list)
{
    public PagedList<UserDto> List { get; set; } = list;
}

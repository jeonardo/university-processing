using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Admin.GetUsers;

public sealed class GetUsersResponseDto(PagedList<UserDto> list)
{
    public PagedList<UserDto> List { get; set; } = list;
}

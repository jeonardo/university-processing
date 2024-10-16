using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Admin;

public sealed class AdminGetUsersResponseDto(PagedList<UserDto> list)
{
    public PagedList<UserDto> List { get; set; } = list;
}

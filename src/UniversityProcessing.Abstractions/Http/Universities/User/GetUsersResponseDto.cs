using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.User;

public sealed class GetUsersResponseDto(PagedList<UserDto> list)
{
    public PagedList<UserDto> List { get; set; } = list;
}

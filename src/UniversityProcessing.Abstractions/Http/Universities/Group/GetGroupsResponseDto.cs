using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class GetGroupsResponseDto(PagedList<GroupDto> list)
{
    public PagedList<GroupDto> List { get; set; } = list;
}

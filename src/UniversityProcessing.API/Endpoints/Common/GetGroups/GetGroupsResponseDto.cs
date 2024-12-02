using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Common.GetGroups;

public sealed class GetGroupsResponseDto(PagedList<GroupDto> list)
{
    public PagedList<GroupDto> List { get; set; } = list;
}

using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class GroupListResponseDto(PagedList<GroupDto> list)
{
    public PagedList<GroupDto> List { get; set; } = list;
}
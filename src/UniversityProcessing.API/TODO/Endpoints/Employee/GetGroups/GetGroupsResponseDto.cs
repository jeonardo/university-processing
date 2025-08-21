using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.GetGroups;

public sealed class GetGroupsResponseDto(PagedList<GroupDto> list)
{
    public PagedList<GroupDto> List { get; set; } = list;
}

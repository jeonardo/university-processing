using UniversityProcessing.Abstractions.Http.Universities.Group;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Groups.Get;
using UniversityProcessing.DomainServices.Features.Groups.GetList;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Converters;

internal static class GroupConverter
{
    public static PagedList<GroupDto> ToDto(PagedList<Group> input)
    {
        return new PagedList<GroupDto>(input.Items.Select(ToDto), input.TotalCount, input.CurrentPage, input.PageSize);
    }

    public static GroupDto ToDto(Group input)
    {
        return new GroupDto(input.Id, input.Number);
    }

    public static GetGroupsResponseDto ToDto(GetGroupsQueryResponse input)
    {
        return new GetGroupsResponseDto(ToDto(input.List));
    }

    public static GetGroupResponseDto ToDto(GetGroupQueryResponse response)
    {
        return new GetGroupResponseDto(ToDto(response.Group));
    }
}

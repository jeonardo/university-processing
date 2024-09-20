using UniversityProcessing.Abstractions.Http.Universities.Group;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class GroupConverter
{
    public static PagedList<GroupDto> ToPagedDto(IEnumerable<Group> input, int totalCount, int pageNumber, int pageSize)
    {
        return new PagedList<GroupDto>(ToDto(input), totalCount, pageNumber, pageSize);
    }

    public static IEnumerable<GroupDto> ToDto(IEnumerable<Group> input)
    {
        return input.Select(ToDto);
    }

    public static GroupDto ToDto(Group input)
    {
        return new GroupDto(input.Id, input.Number);
    }
}

using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Converters;

public static class UniversityPositionConverter
{
    public static PagedList<UniversityPositionDto> ToDto(PagedList<UniversityPosition> input)
    {
        return new PagedList<UniversityPositionDto>(ToDto(input.Items), input.TotalCount, input.CurrentPage, input.PageSize);
    }

    public static IEnumerable<UniversityPositionDto> ToDto(IEnumerable<UniversityPosition> input)
    {
        return input.Select(ToDto);
    }

    public static UniversityPositionDto ToDto(UniversityPosition input)
    {
        return new UniversityPositionDto(input.Id, input.Name);
    }
}

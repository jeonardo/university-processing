using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class UniversityPositionConverter
{
    public static PagedList<UniversityPositionDto> ToPagedDto(IEnumerable<UniversityPosition> input, int totalCount, int pageNumber, int pageSize)
    {
        return new PagedList<UniversityPositionDto>(ToDto(input), totalCount, pageNumber, pageSize);
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

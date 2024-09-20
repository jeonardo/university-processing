using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class UniversityConverter
{
    public static PagedList<UniversityDto> ToPagedDto(IEnumerable<University> input, int totalCount, int pageNumber, int pageSize)
    {
        return new PagedList<UniversityDto>(ToDto(input), totalCount, pageNumber, pageSize);
    }

    public static IEnumerable<UniversityDto> ToDto(IEnumerable<University> input)
    {
        return input.Select(ToDto);
    }

    public static UniversityDto ToDto(University input)
    {
        return new UniversityDto(input.Id, input.Name, input.ShortName);
    }
}

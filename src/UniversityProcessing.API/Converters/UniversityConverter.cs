using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Converters;

public static class UniversityConverter
{
    public static PagedList<UniversityDto> ToDto(PagedList<University> input)
    {
        return new PagedList<UniversityDto>(ToDto(input.Items), input.TotalCount, input.CurrentPage, input.PageSize);
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

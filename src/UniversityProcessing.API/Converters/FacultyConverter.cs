using UniversityProcessing.Abstractions.Http.Universities.Faculty;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Converters;

public static class FacultyConverter
{
    public static PagedList<FacultyDto> ToDto(PagedList<Faculty> input)
    {
        return new PagedList<FacultyDto>(ToDto(input.Items), input.TotalCount, input.CurrentPage, input.PageSize);
    }

    public static IEnumerable<FacultyDto> ToDto(IEnumerable<Faculty> input)
    {
        return input.Select(ToDto);
    }

    public static FacultyDto ToDto(Faculty input)
    {
        return new FacultyDto(input.Id, input.Name, input.ShortName);
    }
}

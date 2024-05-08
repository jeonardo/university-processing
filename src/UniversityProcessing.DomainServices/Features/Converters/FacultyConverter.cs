using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Converters;

internal static class FacultyConverter
{
    public static PagedList<FacultyDto> ToPagedDto(IEnumerable<Faculty> input, int totalCount, int pageNumber, int pageSize)
    {
        return new PagedList<FacultyDto>(ToDto(input), totalCount, pageNumber, pageSize);
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
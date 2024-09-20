using UniversityProcessing.Abstractions.Http.Universities.Specialty;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class SpecialtyConverter
{
    public static PagedList<SpecialtyDto> ToPagedDto(IEnumerable<Specialty> input, int totalCount, int pageNumber, int pageSize)
    {
        return new PagedList<SpecialtyDto>(ToDto(input), totalCount, pageNumber, pageSize);
    }

    public static IEnumerable<SpecialtyDto> ToDto(IEnumerable<Specialty> input)
    {
        return input.Select(ToDto);
    }

    public static SpecialtyDto ToDto(Specialty input)
    {
        return new SpecialtyDto(input.Id, input.Name, input.ShortName, input.Code);
    }
}
